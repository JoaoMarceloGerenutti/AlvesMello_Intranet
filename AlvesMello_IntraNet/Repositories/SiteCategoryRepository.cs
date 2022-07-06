using AlvesMello_IntraNet.Context;
using AlvesMello_IntraNet.Models;
using AlvesMello_IntraNet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlvesMello_IntraNet.Repositories
{
    public class SiteCategoryRepository : ISiteCategoryRepository
    {
        private readonly AppDbContext _context;

        public SiteCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SiteCategory> SiteCategories => _context.SitesCategories;
    }
}
