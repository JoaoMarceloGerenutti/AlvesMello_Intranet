using System.ComponentModel.DataAnnotations;

namespace AlvesMello_IntraNet.ViewModels;

public class ProfileViewModel
{
    [Required(ErrorMessage = "Informe um Nome!")]
    [Display(Name = "Nome Completo")]
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }

    [Required(ErrorMessage = "Informe um E-mail!")]
    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "E-mail Inválido!")]
    public string Email { get; set; }
    public int TelephoneExtension { get; set; }
    public int AM { get; set; }
}
