using System.ComponentModel.DataAnnotations;

namespace ManageCustomer.Application.DTOs
{
    public class CustomerListDto
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
    }

    public class CreateUpdateCustomerDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome não pode ultrapassar 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida")]
        public DateTime DataNascimento { get; set; }
    }

}
