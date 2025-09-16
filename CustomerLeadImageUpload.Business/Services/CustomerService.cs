using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure.Core;
using CustomerLeadImageUpload.Business.Extensions;
using CustomerLeadImageUpload.Business.Models.DTOs;
using CustomerLeadImageUpload.Business.Services.Interface;
using CustomerLeadImageUpload.Data;
using CustomerLeadImageUpload.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLeadImageUpload.Business.Services
{
  public class CustomerService : ICustomerService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper=mapper;
    }

    public async Task<List<CustomerDTO>> GetCustomerAsync()
    {
      var customers = await _unitOfWork.Repository<Customer>().GetAllAsync();

      var res = _mapper.Map<List<CustomerDTO>>(customers);

      return res;
    }
  }
}
