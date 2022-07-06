using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLayer.DTOs;
using DomainLayer.Models.orders;

namespace WebAppOnionArchitecture.Heplers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddOrderDTO, OrderHeader>();
                
            CreateMap<OrderDetailsDTO, OrderDetails > ();
        }
    }
}
