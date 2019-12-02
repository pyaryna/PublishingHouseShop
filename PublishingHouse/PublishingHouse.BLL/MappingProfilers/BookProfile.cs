using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.MappingProfilers
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookPreviewDto>()
                .ReverseMap();

            CreateMap<Book, BookDto>()
                .ForMember(b => b.Authors, opt => opt.MapFrom(x => x.BookAuthors))
                .ForMember(b => b.Categories, opt => opt.MapFrom(x => x.BookCategories))
                .ForMember(b => b.Comments, opt => opt.MapFrom(x => x.Comments));
                //.ReverseMap();
        }        
    }
}
