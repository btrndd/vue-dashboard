using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
  public class RequestLogin
  {
    [Required(ErrorMessage = "O campo 'email' é obrigatório.")]
    [EmailAddress(ErrorMessage = "Por favor, insira um email válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo 'senha' é obrigatório")]
    public string Password { get; set; }
  }
}