using Microsoft.EntityFrameworkCore;
using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Repositories
{
    public class NotificationRepository : Repository<Notification, int>, INotificationRepository
    {
        public NotificationRepository(PublishingHouseContext context) : base(context) { }

        public async Task<Notification> FindAsync(int id)
        {
            return await Context.Notifications
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await Context.Notifications
                .ToListAsync();
        }
    }
}
