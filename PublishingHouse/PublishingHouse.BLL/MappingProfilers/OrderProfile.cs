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

            CreateMap<AddOrderDto, Order>()
                .ForMember(b => b.Id, opt => opt.Ignore())
                .ForMember(b => b.BookOrders, opt => opt.Ignore());

            CreateMap<Order, OrderDto>()
                .ForMember(b => b.Books, opt => opt.MapFrom(x => x.BookOrders));
        }
    }
}
