using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerLeadImageUpload.Data.Models
{
    [Table("CustomerImage")]
    public class CustomerImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }

        [Required]
        public string Base64Data { get; set; } = null!;
        public string MimeType { get; set; } = null!;
  }
}
