using System.ComponentModel.DataAnnotations;

namespace backend.ViewModels
{
    public class EditorUserViewModel
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
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(6, ErrorMessage = "Este campo deve conter no mínimo 6 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Status { get; set; }
    }
}