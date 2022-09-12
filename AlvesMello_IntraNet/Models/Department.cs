using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlvesMello_IntraNet.Models;

[Table("Departments")]
public class Department
{
    [Key]
    [Column("DepartmentId")]
    public int DepartmentId { get; set; }

    [StringLength(7, ErrorMessage = "A cor não pode Exceder {1} caracteres")]
    [Required(ErrorMessage = "A Cor do Departamento é Obrigatória!")]
    [Display(Name = "Cor do Departamento")]
    public string Color { get; set; }

    [StringLength(50, ErrorMessage = "O Nome não pode Exceder {1} caracteres")]
    [Required(ErrorMessage = "O Nome do Departamento é Obrigatório!")]
    [Display(Name = "Nome do Departamento")]
    public string Name { get; set; }

    [StringLength(200, ErrorMessage = "A Descrição não pode Exceder {1} caracteres")]
    [Display(Name = "Descrição do Departamento")]
    public string Description { get; set; }

    public List<Site> Sites { get; set; }
    public List<ApplicationUser> Users { get; set; }
}
