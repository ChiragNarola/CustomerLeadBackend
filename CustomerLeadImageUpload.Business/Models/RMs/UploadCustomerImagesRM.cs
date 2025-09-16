using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLeadImageUpload.Business.Models.RMs
{
  public class UploadCustomerImagesRM
  {
    [Required]
    public int CustomerId { get; set; }

    [Required]
    public List<IFormFile> Images { get; set; } = new List<IFormFile>();
  }
}
