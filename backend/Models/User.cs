using System.ComponentModel.DataAnnotations;

namespace backend.Models {
  public class User : Entity {

    [Required(ErrorMessage = "O campo 'nome' é obrigatório")]
    [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo 'sobrenome' é obrigatório")]
    [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "O campo 'email' é obrigatório.")]
    [EmailAddress(ErrorMessage = "Por favor, insira um email válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo 'telefone' é obrigatório")]
    [MaxLength(15, ErrorMessage = "Seu telefone deve conter entre 14 e 15 caracteres")]
    [MinLength(14, ErrorMessage = "Seu telefone deve conter entre 14 e 15 caracteres")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "O campo 'data de nascimento' é obrigatório")]
    // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
    // [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }     
  }
}