using System.ComponentModel.DataAnnotations;

namespace DesafioBackCodgoX.Application.DTOs
{
    public class CreateUpdateUserDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres")]
        [MaxLength(12, ErrorMessage = "A senha deve conter no máximo 12 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,12}$", ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial")]
        public string Password { get; set; } = string.Empty;
    }
}
