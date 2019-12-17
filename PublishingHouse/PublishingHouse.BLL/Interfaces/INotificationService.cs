using PublishingHouse.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.BLL.Interfaces
{
    public interface INotificationService
    {
        Task<NotificationDto> AddNotificationAsync(CallbackDto callback);

        Task<NotificationDto> GetOneNotificationInfoAsync(int id);

        Task<IEnumerable<NotificationDto>> GetAllNotificationsInfoAsync();

        Task RemoveNotificationByIdAsync(int id);
    }
}
