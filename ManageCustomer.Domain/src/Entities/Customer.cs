using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageCustomer.Domain.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(100)]
        public string? Nome { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        [StringLength(11)]
        public string? Telefone { get; set; }

        [StringLength(11)]
        public DateTime DataNascimento { get; set; }
    }
}
