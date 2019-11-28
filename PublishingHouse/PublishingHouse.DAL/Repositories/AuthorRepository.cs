using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Repositories
{
    public class AuthorRepository : Repository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(PublishingHouseContext context) : base(context) { }
    }
}
