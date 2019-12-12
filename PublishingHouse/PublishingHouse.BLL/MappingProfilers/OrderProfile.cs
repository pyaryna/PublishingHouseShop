using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.MappingProfilers
{
    class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CartDto, Order>()
                 .ForMember(b => b.Id, opt => opt.Ignore());
        }
    }
}
