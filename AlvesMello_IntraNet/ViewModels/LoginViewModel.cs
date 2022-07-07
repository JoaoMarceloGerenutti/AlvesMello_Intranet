using System.ComponentModel.DataAnnotations;

namespace AlvesMello_IntraNet.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe um E-mail!")]
    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "E-mail Inválido!")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Informe a Senha")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
}
