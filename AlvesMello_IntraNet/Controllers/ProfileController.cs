using AlvesMello_IntraNet.Context;
using AlvesMello_IntraNet.Models;
using AlvesMello_IntraNet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> UpdateAsync()
        {
            var user = await _context.Users
                                .Include(u => u.Department)
                                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var profileVM = new ProfileViewModel
            {
                Id = user.Id,
                Photo = user.Photo,
                FullName = user.FullName,
                BirthDate = user.BirthDate,
                PhoneNumber = user.PhoneNumber,
                Email = user.UserName,
                TelephoneExtension = user.TelephoneExtension,
                AM = user.AM
            };

            if (user.Department != null)
            {
                profileVM.DepartmentId = user.Department.DepartmentId;
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", profileVM.DepartmentId);

            if (string.IsNullOrWhiteSpace(profileVM.Photo))
            {
                profileVM.Photo = "/images/ProfileImage.png";
            }

            return View(profileVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProfileViewModel profileVM)
        {
            if (!ModelState.IsValid)
            {
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name");
                return View(profileVM);
            }

            ApplicationUser updateUser = null;
            if (await VerifyUserPassword(profileVM.Password))
            {
                // Update profile information on database.
                updateUser = await _context.Users
                                                .FirstOrDefaultAsync(u => u.Id == profileVM.Id);

                updateUser.FullName = profileVM.FullName;
                updateUser.BirthDate = profileVM.BirthDate;
                updateUser.PhoneNumber = profileVM.PhoneNumber;
                updateUser.TelephoneExtension = profileVM.TelephoneExtension;
                updateUser.AM = profileVM.AM;
                updateUser.Department = await _context.Departments.FindAsync(profileVM.DepartmentId);

                if (!string.IsNullOrEmpty(profileVM.NewPassword))
                {
                    await _userManager.ChangePasswordAsync(updateUser, profileVM.Password, profileVM.NewPassword);
                }

                ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", updateUser.Department.DepartmentId);
                await _context.SaveChangesAsync();
            }

            return View(profileVM);
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
            return Redirect("Update");
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
