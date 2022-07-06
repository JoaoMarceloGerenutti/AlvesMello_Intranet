using AlvesMello_IntraNet.Models;
using Microsoft.EntityFrameworkCore;

namespace AlvesMello_IntraNet.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Site> Sites { get; set; }
    public DbSet<FavoriteUserSite> FavoriteUserSites { get; set; }
}
