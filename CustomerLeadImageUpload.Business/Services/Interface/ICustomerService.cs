using CustomerLeadImageUpload.Business.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLeadImageUpload.Business.Services.Interface
{
  public interface ICustomerService
  {
    Task<List<CustomerDTO>> GetCustomerAsync();
  }
}
