using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBackCodgoX.Domain.Entities
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(12)]
        public string Password { get; set; }
    }
}
