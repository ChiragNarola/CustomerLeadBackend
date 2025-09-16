using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerLeadImageUpload.Data.Models
{
    [Table("Customer")]
    public class Customer 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = null!;

        [MaxLength(200)]
        public string Email { get; set; } = null!;
        [Required]
        public string ContactNumber { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<CustomerImage>? CustomerImages { get; set; }
    }
}
