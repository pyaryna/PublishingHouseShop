using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.MappingProfilers
{
    public class BookAuthorProfile: Profile
    {
        public BookAuthorProfile()
        {
            CreateMap<BookAuthor, AuthorDto>()
                .ForMember(i => i.Id, opt => opt.MapFrom(x => x.Author.Id))
                .ForMember(i => i.Name, opt => opt.MapFrom(x => x.Author.Name));
        }
    }
}
