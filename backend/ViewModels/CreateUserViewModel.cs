using System.ComponentModel.DataAnnotations;

namespace backend.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public string BirthDate { get; set; }        

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(6, ErrorMessage = "Este campo deve conter no mínimo 6 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public bool Status { get; set; }
    }
}