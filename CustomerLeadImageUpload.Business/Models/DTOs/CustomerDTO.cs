using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLeadImageUpload.Business.Models.DTOs
{
  public class CustomerDTO
  {
      public int Id { get; set; }

      public string Name { get; set; } = null!;

      public string Email { get; set; } = null!;
      public string ContactNumber { get; set; } = null!;

      public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  }
}
