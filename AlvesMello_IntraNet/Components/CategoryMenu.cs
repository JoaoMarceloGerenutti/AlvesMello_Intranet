using AlvesMello_IntraNet.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlvesMello_IntraNet.Components;

public class CategoryMenu : ViewComponent
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryMenu(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IViewComponentResult Invoke()
    {
        var categories = _categoryRepository.Categories.OrderBy(c => c.Name);
        return View(categories);
    }
}
