using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlvesMello_IntraNet.Models;

[Table("SitesDepartments")]
[Keyless]
public class SiteDepartment
{
    [Required(ErrorMessage = "O Id do Site é Obrigatório!")]
    [Display(Name = "Id do Site")]
    public int SiteId { get; set; }

    [Required(ErrorMessage = "O Site é Obrigatório!")]
    [Display(Name = "Site")]
    public Site Site { get; set; }

    [Required(ErrorMessage = "Id do Departamento é Obrigatório!")]
    [Display(Name = "Id do Departamento")]
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "O Departamento é Obrigatório!")]
    [Display(Name = "Departamento")]
    public Department Department { get; set; }
}
