using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.MappingProfilers
{
    public class CommentProfile: Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ReverseMap();

            CreateMap<AddCommentDto, Comment>()
                .ForMember(b => b.Id, opt => opt.Ignore()); ;
        }        
    }
}
