using System.ComponentModel.DataAnnotations;

namespace backend.Models {
  public class Auth : Entity {

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MinLength(6, ErrorMessage = "Sua senha precisa ter no mínimo 6 digitos.")]
    [RegularExpression(@"(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,60})$", ErrorMessage = "Sua senha precisa ter no mínimo um número.")]
    public string Password { get; set; }
    public bool Status { get; set; }
  }
}