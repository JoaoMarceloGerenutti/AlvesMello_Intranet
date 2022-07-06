using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlvesMello_IntraNet.Models;

[Table("SitesCategories")]
[Keyless]
public class SiteCategory
{
    [Required(ErrorMessage = "O Id do Site é Obrigatório!")]
    [Display(Name = "Id do Site")]
    public int SiteId { get; set; }

    [Required(ErrorMessage = "O Site é Obrigatório!")]
    [Display(Name = "Site")]
    public Site Site { get; set; }

    [Required(ErrorMessage = "Id da Categoria é Obrigatório!")]
    [Display(Name = "Id da Categoria")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "A Categoria é Obrigatório!")]
    [Display(Name = "Categoria")]
    public Category Category { get; set; }
}
