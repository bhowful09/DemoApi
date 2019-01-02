using AutoMapper;
using DemoApi.Data.Entities;
using DemoApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApi.Logic
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerEntity, Customer>().ReverseMap();
            CreateMap<CustomerEntity, CustomerCreate>().ReverseMap();
            //CreateMap<IEnumerable<CustomerEntity>, IEnumerable<Customer>>().ReverseMap();
        }
    }
}