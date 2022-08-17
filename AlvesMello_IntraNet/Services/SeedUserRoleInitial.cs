using AlvesMello_IntraNet.Models;
using Microsoft.AspNetCore.Identity;

namespace AlvesMello_IntraNet.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly string roleMember = "Member";
        private readonly string roleAdmin = "Admin";

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync(roleMember).Result)
            {
                IdentityRole role = new()
                {
                    Name = roleMember,
                    NormalizedName = roleMember.ToUpper()
                };
                _ = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync(roleAdmin).Result)
            {
                IdentityRole role = new()
                {
                    Name = roleAdmin,
                    NormalizedName = roleAdmin.ToUpper()
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            string emailMember = "user@alvesmello.com.br";
            if (_userManager.FindByEmailAsync(emailMember).Result == null)
            {
                ApplicationUser user = new()
                {
                    UserName = emailMember,
                    Email = emailMember,
                    FullName = "Membro - A&M",
                    NormalizedUserName = emailMember.ToUpper(),
                    NormalizedEmail = emailMember.ToUpper(),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(user, "P@nela22").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, roleMember).Wait();
                }
            }

            string emailAdmin = "admin@alvesmello.com.br";
            if (_userManager.FindByEmailAsync(emailAdmin).Result == null)
            {
                ApplicationUser user = new()
                {
                    UserName = emailAdmin,
                    Email = emailAdmin,
                    FullName = "Administrador - A&M",
                    NormalizedUserName = emailAdmin.ToUpper(),
                    NormalizedEmail = emailAdmin.ToUpper(),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(user, "Alvesmello@123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, roleAdmin).Wait();
                }
            }
        }
    }
}
