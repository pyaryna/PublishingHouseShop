using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order, int>
    {
        Task<Order> FindAsync(int id);
        Task<IEnumerable<Order>> GetUserCartsAsync(string id);
    }
}
