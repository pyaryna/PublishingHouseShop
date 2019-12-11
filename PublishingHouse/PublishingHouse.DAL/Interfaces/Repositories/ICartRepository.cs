using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Interfaces.Repositories
{
    public interface ICartRepository : IRepository<Cart, int>
    {
        Task<Cart> FindAsync(int bookId, string customerId);

        Task<IEnumerable<Cart>> GetUserCartsAsync(string id);
    }
}
