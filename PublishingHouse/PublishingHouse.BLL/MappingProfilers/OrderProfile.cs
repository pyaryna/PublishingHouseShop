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
                 .ForMember(o => o.Id, opt => opt.Ignore());

            CreateMap<AddOrderDto, Order>()
                .ForMember(o => o.Id, opt => opt.Ignore())
                .ForMember(o => o.BookOrders, opt => opt.Ignore());

            CreateMap<Order, OrderDto>()
                .ForMember(o => o.Books, opt => opt.MapFrom(x => x.BookOrders));
        }
    }
}
