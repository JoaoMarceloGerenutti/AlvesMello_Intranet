using AlvesMello_IntraNet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlvesMello_IntraNet.Context;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Site> Sites { get; set; }
    public DbSet<FavoriteUserSite> FavoriteUserSites { get; set; }
}
