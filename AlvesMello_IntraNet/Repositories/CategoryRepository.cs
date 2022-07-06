using AlvesMello_IntraNet.Context;
using AlvesMello_IntraNet.Models;
using AlvesMello_IntraNet.Repositories.Interfaces;

namespace AlvesMello_IntraNet.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> Categories => _context.Categories;
}
