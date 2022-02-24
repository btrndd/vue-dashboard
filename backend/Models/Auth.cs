using System.ComponentModel.DataAnnotations;

namespace backend.Models {
  public class Auth {

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MinLength(6, ErrorMessage = "Este campo deve conter no mínimo 6 caracteres")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public bool Status { get; set; }
  }
}