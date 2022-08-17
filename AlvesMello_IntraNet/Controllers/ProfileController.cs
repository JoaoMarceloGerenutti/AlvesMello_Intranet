using AlvesMello_IntraNet.Models;
using AlvesMello_IntraNet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlvesMello_IntraNet.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
            {
                return Redirect("Home");
            }

            var profileViewModel = new ProfileViewModel
            {
                Name = user.Result.FullName,
                BirthDate = user.Result.BirthDate,
                Phone = user.Result.PhoneNumber,
                Email = user.Result.UserName,
                TelephoneExtension = user.Result.TelephoneExtension,
                AM = user.Result.AM
            };
            return View(profileViewModel);
        }
    }
}
