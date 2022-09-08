using AlvesMello_IntraNet.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlvesMello_IntraNet.Components;

public class DepartmentMenu : ViewComponent
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentMenu(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public IViewComponentResult Invoke()
    {
        var departments = _departmentRepository.Departments.OrderBy(c => c.Name);
        return View(departments);
    }
}
