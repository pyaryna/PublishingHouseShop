using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.MappingProfilers
{
    public class BookOrderProfile: Profile
    {
        public BookOrderProfile()
        {
            CreateMap<BookOrder, BookPreviewDto>()
                .ForMember(b => b.Id, opt => opt.MapFrom(x => x.Book.Id))
                .ForMember(b => b.ImageUrl, opt => opt.MapFrom(x => x.Book.ImageUrl))
                .ForMember(b => b.Price, opt => opt.MapFrom(x => x.Book.Price))
                .ForMember(b => b.Title, opt => opt.MapFrom(x => x.Book.Title));
        }
    }
}
