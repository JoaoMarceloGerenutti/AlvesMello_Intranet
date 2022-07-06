using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlvesMello_IntraNet.Models;

[Table("Categories")]
public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [StringLength(6, ErrorMessage = "A cor não pode Exceder {1} caracteres")]
    [Required(ErrorMessage = "A Cor da Categoria é Obrigatória!")]
    [Display(Name = "Cor da Categoria")]
    public string Color { get; set; }

    [StringLength(50, ErrorMessage = "O Nome não pode Exceder {1} caracteres")]
    [Required(ErrorMessage = "O Nome da Categoria é Obrigatório!")]
    [Display(Name = "Nome da Categoria")]
    public string Name { get; set; }

    [StringLength(200, ErrorMessage = "A Descrição não pode Exceder {1} caracteres")]
    [Required(ErrorMessage = "A Descrição da Categoria é Obrigatório!")]
    [Display(Name = "Descrição da Categoria")]
    public string Description { get; set; }

    public List<Site> Sites { get; set; }
}
