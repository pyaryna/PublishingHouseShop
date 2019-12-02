using Microsoft.EntityFrameworkCore;
using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Repositories
{
    public class AuthorRepository : Repository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(PublishingHouseContext context) : base(context) { }

        public async Task<Author> FindAsync(int key)
        {
            return await Context.Set<Author>()
                .FirstOrDefaultAsync(x => x.Id.Equals(key));
        }
    }
}
