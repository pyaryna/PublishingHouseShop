using Microsoft.EntityFrameworkCore;
using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Repositories
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(PublishingHouseContext context) : base(context) { }

        public async Task<Order> FindAsync(int id)
        {
            return await Context.Orders
                .Include(o => o.Customer)
                .Include(o => o.BookOrders)
                .ThenInclude(bo => bo.Book)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
