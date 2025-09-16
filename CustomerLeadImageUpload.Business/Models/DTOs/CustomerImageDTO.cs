using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLeadImageUpload.Business.Models.DTOs
{
  public class CustomerImageDTO
  {
    public int Id { get; set; }
    public string Base64Data { get; set; } = null!;
    public string MimeType { get; set; } = null!;
  }
}
