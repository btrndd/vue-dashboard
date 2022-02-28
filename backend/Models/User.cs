using System.ComponentModel.DataAnnotations;

namespace backend.Models {
  public class User {

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório.")]
    [EmailAddress(ErrorMessage = "Por favor, insira um email válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(11, ErrorMessage = "Seu telefone deve conter entre 10 e 11 caracteres")]
    [MinLength(10, ErrorMessage = "Seu telefone deve conter entre 10 e 11 caracteres")]
    [Phone(ErrorMessage = "Por favor, insira um número válido.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
  }
}