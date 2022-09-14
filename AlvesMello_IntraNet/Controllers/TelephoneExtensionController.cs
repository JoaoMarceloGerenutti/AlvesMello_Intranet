using AlvesMello_IntraNet.Context;
using AlvesMello_IntraNet.Models;
using AlvesMello_IntraNet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlvesMello_IntraNet.Controllers
{
    public class TelephoneExtensionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TelephoneExtensionController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var usersInDb = new List<ApplicationUser>();
            usersInDb = _context.Users.Include(d => d.Department)
                                        .OrderBy(d => d.Department.Name)
                                        .Where(t => t.TelephoneExtension != 0)
                                        .ToList();

            List<List<ApplicationUser>> usersByDepartment = new List<List<ApplicationUser>>();

            List<ApplicationUser> users = new List<ApplicationUser>();
            var i = 0;
            var index = 0;
            foreach (var user in usersInDb)
            {
                if (i == 0)
                {
                    if (users.Count() > 0)
                    {
                        if (users[users.Count - 1].Department != user.Department)
                        {
                            usersByDepartment.Add(users);
                            users = new List<ApplicationUser>();
                        }
                    }
                    users.Add(user);
                }
                else
                {
                    if (users[i - 1].Department != user.Department)
                    {
                        usersByDepartment.Add(users);
                        users = new List<ApplicationUser>();
                        i = -1;
                    }
                    users.Add(user);
                }
                i++;

                if (++index == usersInDb.Count())
                {
                    usersByDepartment.Add(users);
                }
            }

            var telephoneExtensionVM = new TelephoneExtensionViewModel()
            {
                UsersByDepartment = usersByDepartment
            };
            return View(telephoneExtensionVM);
        }
    }
}
