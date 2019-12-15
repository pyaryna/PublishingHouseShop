using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Repositories
{
    public class NotificationRepository : Repository<Notification, int>, INotificationRepository
    {
        public NotificationRepository(PublishingHouseContext context) : base(context) { }
    }
}
