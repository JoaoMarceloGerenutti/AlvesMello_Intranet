using AlvesMello_IntraNet.Context;
using AlvesMello_IntraNet.Models;
using AlvesMello_IntraNet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AlvesMello_IntraNet.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ConfigurationImages _myConfig;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProfileController(AppDbContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IOptions<ConfigurationImages> myConfig,
            IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _myConfig = myConfig.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
            {
                return Redirect("Home");
            }

            var profileVM = new ProfileViewModel
            {
                Id = user.Result.Id,
                Photo = user.Result.Photo,
                FullName = user.Result.FullName,
                BirthDate = user.Result.BirthDate,
                PhoneNumber = user.Result.PhoneNumber,
                Email = user.Result.UserName,
                TelephoneExtension = user.Result.TelephoneExtension,
                AM = user.Result.AM
            };

            if (string.IsNullOrWhiteSpace(profileVM.Photo))
            {
                profileVM.Photo = "/images/ProfileImage.png";
            }

            return View(profileVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile([Bind("Id, FullName, BirthDate, PhoneNumber, TelephoneExtension, AM")] ApplicationUser applicationUser, string password, string newPassword)
        {
            if (ModelState.IsValid)
            {
                if (await VerifyUserPassword(password))
                {
                    // Update profile information on database.
                    ApplicationUser updateUser = _context.Users
                                                    .FirstOrDefault(u => u.Id == applicationUser.Id);

                    updateUser.FullName = applicationUser.FullName;
                    updateUser.BirthDate = applicationUser.BirthDate;
                    updateUser.PhoneNumber = applicationUser.PhoneNumber;
                    updateUser.TelephoneExtension = applicationUser.TelephoneExtension;
                    updateUser.AM = applicationUser.AM;

                    if (!string.IsNullOrEmpty(newPassword))
                    {
                        await _userManager.ChangePasswordAsync(updateUser, password, newPassword);
                    }

                    await _context.SaveChangesAsync();
                }
            }
            return Redirect("Index");
        }

        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            // Save image on user's folder.
            if (file != null)
            {
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                _myConfig.FolderNameImagesUsers);

                if (file.FileName.Contains(".jpg")
                        || file.FileName.Contains(".gif")
                        || file.FileName.Contains(".png"))
                {
                    ApplicationUser applicationUser = await _userManager.FindByNameAsync(User.Identity.Name);

                    var fileNameWithPath = string.Concat(filePath, @"\", applicationUser.UserName, @"\", file.FileName);

                    var path = string.Concat(filePath, @"\", applicationUser.UserName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var userPath = @"/" + _myConfig.FolderNameImagesUsers + @"/" + applicationUser.UserName;
                    var dbFilePath = userPath + @"/" + file.FileName;

                    applicationUser.Photo = dbFilePath;

                    await _context.SaveChangesAsync();
                }
            }
            return Redirect("Index");
        }

        private async Task<bool> VerifyUserPassword(string password)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _signInManager.PasswordSignInAsync(user, password, true, false);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
