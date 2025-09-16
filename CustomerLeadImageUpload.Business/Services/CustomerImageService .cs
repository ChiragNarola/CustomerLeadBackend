using AutoMapper;
using CustomerLeadImageUpload.Business.Models.DTOs;
using CustomerLeadImageUpload.Business.Models.RMs;
using CustomerLeadImageUpload.Business.Services.Interface;
using CustomerLeadImageUpload.Data;
using CustomerLeadImageUpload.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CustomerLeadImageUpload.Business.Services
{
  public class CustomerImageService : ICustomerImageService
  {
    private readonly IUnitOfWork _unitOfWork;
    private const int MaxImagesPerCustomer = 10;
    private readonly IMapper _mapper;
    public CustomerImageService(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper=mapper;
    }
    public async Task<List<CustomerImageDTO>> UploadImagesAsync(UploadCustomerImagesRM model)
    {
      var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(model.CustomerId);
      if (customer == null)
        throw new Exception("Customer not found");

      var existingCount = customer.CustomerImages?.Count ?? 0;
      if (existingCount + model.Images.Count > MaxImagesPerCustomer)
        throw new ArgumentException($"Cannot upload more than {MaxImagesPerCustomer} images per customer");

      var uploadedImages = new List<CustomerImage>();

      foreach (var file in model.Images)
      {
        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        var base64 = Convert.ToBase64String(ms.ToArray());

        var customerImage = new CustomerImage
        {
          CustomerId = model.CustomerId,
          Base64Data = base64,
          MimeType = file.ContentType,
        };

        uploadedImages.Add(customerImage);
      }

      await _unitOfWork.Repository<CustomerImage>().AddRangeAsync(uploadedImages);
      await _unitOfWork.SaveAsync();

      var res = _mapper.Map<List<CustomerImageDTO>>(uploadedImages);
      return res;
    }

    public async Task<List<CustomerImageDTO>> GetImagesByCustomerIdAsync(int customerId)
    {
      var images = await _unitOfWork.Repository<CustomerImage>()
          .GetAsync(x => x.CustomerId == customerId);

      var res = _mapper.Map<List<CustomerImageDTO>>(images);
      return res;
    }

    public async Task DeleteImageAsync(int imageId)
    {
      var image = await _unitOfWork.Repository<CustomerImage>().GetByIdAsync(imageId);
      if (image == null)
        throw new Exception("Image not found");

      _unitOfWork.Repository<CustomerImage>().Remove(image);
      await _unitOfWork.SaveAsync();
    }
  }
}
