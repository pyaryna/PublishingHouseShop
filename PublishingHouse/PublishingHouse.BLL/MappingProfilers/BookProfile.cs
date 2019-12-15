using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

            CreateMap<AddBookDto, Book>()
                .ForMember(b => b.Id, opt => opt.Ignore())
                .ForMember(b => b.BookAuthors, opt => opt.Ignore())
                .ForMember(b => b.BookCategories, opt => opt.Ignore())
                .ForMember(b => b.BookOrders, opt => opt.Ignore())
                .ForMember(b => b.Comments, opt => opt.Ignore())
                .ForMember(b => b.ImageUrl, opt => opt.Ignore());

            CreateMap<UpdateBookDto, Book>()
                .ForMember(b => b.BookAuthors, opt => opt.Ignore())
                .ForMember(b => b.BookCategories, opt => opt.Ignore())
                .ForMember(b => b.BookOrders, opt => opt.Ignore())
                .ForMember(b => b.ImageUrl, opt => opt.Ignore());

            CreateMap<Book, UpdateBookDto>()
                .ForMember(b => b.Authors, opt => opt.Ignore())
                .ForMember(b => b.Categories, opt => opt.Ignore())
                .ForMember(b => b.AuthorId, opt => opt.MapFrom(x => x.BookAuthors.FirstOrDefault(y => y.BookId == x.Id).AuthorId))
                .ForMember(b => b.CategoryId, opt => opt.MapFrom(x => x.BookCategories.FirstOrDefault(y => y.BookId == x.Id).CategoryId))
                .ForMember(b => b.ExistingImagePath, opt => opt.MapFrom(x => x.ImageUrl));
        }
    }
}
