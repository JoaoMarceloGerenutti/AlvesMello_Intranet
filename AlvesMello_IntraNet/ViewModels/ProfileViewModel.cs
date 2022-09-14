using System.ComponentModel.DataAnnotations;

namespace AlvesMello_IntraNet.ViewModels;
public class ProfileViewModel
{
    [Key]
    public string Id { get; set; }

    [Display(Name = "Foto de Perfil")]
    public string Photo { get; set; }

    [Required(ErrorMessage = "Informe seu Nome Completo!")]
    [Display(Name = "Nome Completo")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Informe sua Data de Nascimento!")]
    [Display(Name = "Data de Nascimento")]
    public DateTime BirthDate { get; set; }

    [Display(Name = "Celular")]
    [RegularExpression(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Celular Inválido!")]
    public string PhoneNumber { get; set; }

    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "E-mail Inválido!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe seu Ramal! (0 caso não tenha)")]
    [Display(Name = "Ramal")]
    public int TelephoneExtension { get; set; }

    [Required(ErrorMessage = "Informe o Número do seu AM! (localizado em cima do seu Computador)")]
    [Display(Name = "Número do AM")]
    public int AM { get; set; }

    [Display(Name = "Departamento")]
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "Informe a Senha Atual!")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha Atual")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Nova Senha")]
    public string NewPassword { get; set; }
}
