using AutoMapper;
using PublishingHouse.BLL.Interfaces;
using PublishingHouse.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IPublishingHouseUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationService(
            IPublishingHouseUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
