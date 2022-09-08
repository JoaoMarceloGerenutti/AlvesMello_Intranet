using AlvesMello_IntraNet.Context;
using AlvesMello_IntraNet.Models;
using AlvesMello_IntraNet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlvesMello_IntraNet.Repositories;

public class SiteRepository : ISiteRepository
{
    private readonly AppDbContext _context;

    public SiteRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Site> Sites => _context.Sites.
                                Include(c => c.Department);

    public IEnumerable<Site> FavoriteSites => _context.Sites.
                                Where(s => s.IsFavorite).
                                Include(c => c.Department);

    public Site GetSiteById(int siteId) => _context.Sites.
                                FirstOrDefault(s => s.SiteId == siteId);
}
