using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Interfaces.Repositories
{
    public interface INotificationRepository : IRepository<Notification, int>
    {
        Task<Notification> FindAsync(int id);

        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
    }
}
