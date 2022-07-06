using AlvesMello_IntraNet.Context;
using Microsoft.EntityFrameworkCore;

namespace AlvesMello_IntraNet.Models;

public class FavoriteSite
{
    private readonly AppDbContext _context;

    public FavoriteSite(AppDbContext context)
    {
        _context = context;
    }

    public string FavoriteSiteId { get; set; }
    public List<FavoriteUserSite> FavoriteUserSites { get; set; }

    public static FavoriteSite GetFavorite(IServiceProvider services)
    {
        ISession session =
            services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        var context = services.GetService<AppDbContext>();

        string favoriteId = session.GetString("FavoriteId") ?? Guid.NewGuid().ToString();

        session.SetString("FavoriteId", favoriteId);

        return new FavoriteSite(context)
        {
            FavoriteSiteId = favoriteId
        };
    }

    public void AddToFavorite(Site site)
    {
        var favoriteUserSite = _context.FavoriteUserSites.SingleOrDefault(
                s => s.Site.SiteId == site.SiteId &&
                s.FavoriteSiteId == FavoriteSiteId);

        if (favoriteUserSite == null)
        {
            favoriteUserSite = new FavoriteUserSite
            {
                FavoriteSiteId = FavoriteSiteId,
                Site = site
            };
            _context.FavoriteUserSites.Add(favoriteUserSite);
        }
        _context.SaveChanges();
    }

    public void RemoveFromFavorite(Site site)
    {
        var favoriteUserSite = _context.FavoriteUserSites.SingleOrDefault(
                s => s.Site.SiteId == site.SiteId &&
                s.FavoriteSiteId == FavoriteSiteId);

        if (favoriteUserSite != null)
        {
            _context.FavoriteUserSites.Remove(favoriteUserSite);
        }
        _context.SaveChanges();
    }

    public List<FavoriteUserSite> GetFavoriteUserSites()
    {
        return FavoriteUserSites ?? 
                (FavoriteUserSites = 
                _context.FavoriteUserSites
                .Where(f => f.FavoriteSiteId == FavoriteSiteId)
                .Include(s => s.Site)
                .ToList()
        );
    }

    public void ClearFavorite()
    {
        var favoriteSites = _context.FavoriteUserSites
                            .Where(favorites => favorites.FavoriteSiteId == FavoriteSiteId);

        _context.FavoriteUserSites.RemoveRange(favoriteSites);
        _context.SaveChanges();
    }
}
