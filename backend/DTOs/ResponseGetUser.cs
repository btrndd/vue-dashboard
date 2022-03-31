using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
  public class ResponseGetUser
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo 'nome' é obrigatório")]
    [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo 'sobrenome' é obrigatório")]
    [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "O campo 'telefone' é obrigatório")]
    [MaxLength(11, ErrorMessage = "Seu telefone deve conter entre 10 e 11 caracteres")]
    [MinLength(10, ErrorMessage = "Seu telefone deve conter entre 10 e 11 caracteres")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "O campo 'email' é obrigatório.")]
    [EmailAddress(ErrorMessage = "Por favor, insira um email válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo 'data de nascimento' é obrigatório")]
    public DateTime? BirthDate { get; set; }

    public bool Status { get; set; }
  }
}