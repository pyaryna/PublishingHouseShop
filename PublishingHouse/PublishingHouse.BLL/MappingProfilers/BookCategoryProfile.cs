using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.MappingProfilers
{
    class BookCategoryProfile: Profile
    {
        public BookCategoryProfile()
        {
            CreateMap<BookCategory, CategoryDto>()
                .ForMember(i => i.Id, opt => opt.MapFrom(x => x.Category.Id))
                .ForMember(i => i.Name, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
