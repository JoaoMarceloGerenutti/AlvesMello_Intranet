using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlvesMello_IntraNet.Models;

[Table("Sites")]
public class Site
{
    [Key]
    public int SiteId { get; set; }

    [StringLength(100, ErrorMessage = "O Nome não pode Exceder {1} caracteres")]
    [Required(ErrorMessage = "O Nome do Site é Obrigatório!")]
    [Display(Name = "Nome do Site")]
    public string Name { get; set; }

    [StringLength(200, ErrorMessage = "A Descrição não pode Exceder {1} caracteres")]
    [MinLength(20, ErrorMessage = "A Descrição deve ter no Mínimo {1} caracteres")]
    [Required(ErrorMessage = "A Descrição do Site é Obrigatório!")]
    [Display(Name = "Descrição do Site")]
    public string Description { get; set; }

    [StringLength(200, ErrorMessage = "A URL da Imagem não pode Exceder {1} caracteres")]
    [Display(Name = "URL da Imagem do Site")]
    public string ImageUrl { get; set; }

    [StringLength(200, ErrorMessage = "A URL do Site não pode Exceder {1} caracteres")]
    [Required(ErrorMessage = "A URL do Site é Obrigatória!")]
    [Display(Name = "URL do Site")]
    public string SiteUrl { get; set; }

    [Display(Name = "Favorito?")]
    public bool IsFavorite { get; set; }

    [Display(Name = "Ativo?")]
    public bool IsActive { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}
