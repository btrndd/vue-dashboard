using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class ResponseLogin
    {
        [Key]
        public int Id { get; set ; }

        [Required(ErrorMessage = "O campo 'email' é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um email válido.")]
        public string Email { get; set; }      

        [Required(ErrorMessage = "O campo 'senha' é obrigatório")]
        [MinLength(6, ErrorMessage = "Sua senha precisa ter no mínimo 6 digitos.")]
        [RegularExpression(@"(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,60})$", ErrorMessage = "Sua senha precisa ter no mínimo um número.")]
        public string Password { get; set; }
    }
}