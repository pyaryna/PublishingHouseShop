using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.BLL.Interfaces;
using PublishingHouse.DAL;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<NotificationDto> AddNotificationAsync(CallbackDto callback)
        {
            var notificationEntity = _unitOfWork.Notifications.Add(_mapper.Map<CallbackDto, Notification>(callback));

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Notification, NotificationDto>(notificationEntity);
        }

        public async Task<NotificationDto> GetOneNotificationInfoAsync(int id)
        {
            return _mapper.Map<Notification, NotificationDto>(await _unitOfWork.Notifications.FindAsync(id));
        }

        public async Task<IEnumerable<NotificationDto>> GetAllNotificationsInfoAsync()
        {
            IEnumerable<Notification> notifications = await _unitOfWork.Notifications.GetAllNotificationsAsync();

            return notifications.Select(_mapper.Map<Notification, NotificationDto>)
                .ToArray();
        }

        public async Task RemoveNotificationByIdAsync(int id)
        {
            var notification = await _unitOfWork.Notifications.FindAsync(id);

            _unitOfWork.Notifications.Remove(notification);

            await _unitOfWork.CommitAsync();
        }
    }
}
