using AlvesMello_IntraNet.Models;

namespace AlvesMello_IntraNet.Repositories.Interfaces;

public interface IDepartmentRepository
{
    IEnumerable<Department> Departments { get; }
}
