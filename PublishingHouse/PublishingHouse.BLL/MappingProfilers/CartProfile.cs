using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.MappingProfilers
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartDto>()
                .ReverseMap();

            CreateMap<AddCartDto, Cart>()
                 .ForMember(b => b.Id, opt => opt.Ignore());
        }
    }
}
