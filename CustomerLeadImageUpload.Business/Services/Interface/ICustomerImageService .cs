using CustomerLeadImageUpload.Business.Models.DTOs;
using CustomerLeadImageUpload.Business.Models.RMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLeadImageUpload.Business.Services.Interface
{
  public interface ICustomerImageService
  {
    Task<List<CustomerImageDTO>> UploadImagesAsync(UploadCustomerImagesRM model);
    Task<List<CustomerImageDTO>> GetImagesByCustomerIdAsync(int customerId);
    Task DeleteImageAsync(int imageId);
  }
}
