using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.MappingProfilers
{
    public class NotificationProvider: Profile
    {
        public NotificationProvider()
        {
            CreateMap<Notification, NotificationDto>()
                .ReverseMap();

            CreateMap<CallbackDto, Notification>()
                .ForMember(b => b.Id, opt => opt.Ignore());
        }        
    }
}
