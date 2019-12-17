using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        Task<Category> FindAsync(int key);
    }
}
