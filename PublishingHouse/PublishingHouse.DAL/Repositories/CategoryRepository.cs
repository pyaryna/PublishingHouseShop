using Microsoft.EntityFrameworkCore;
using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(PublishingHouseContext context) : base(context) { }

        public async Task<Category> FindAsync(int key)
        {
            return await Context.Set<Category>()
                .FirstOrDefaultAsync(x => x.Id.Equals(key));
        }
    }
}
