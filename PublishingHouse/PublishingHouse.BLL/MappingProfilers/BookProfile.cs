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
            CreateMap<Book, BookPreviewDto>();
        }        
    }
}
