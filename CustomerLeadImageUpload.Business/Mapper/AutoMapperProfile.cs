using AutoMapper;
using CustomerLeadImageUpload.Business.Models.DTOs;
using CustomerLeadImageUpload.Data.Models;

namespace CustomerLeadImageUpload.Business.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomerImage, CustomerImageDTO>().ReverseMap();
    }
    }
}
