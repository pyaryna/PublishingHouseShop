using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Repositories
{
    public class BookAuthorRepository : Repository<BookAuthor, int>, IBookAuthorRepository
    {
        public BookAuthorRepository(PublishingHouseContext context) : base(context) { }
    }
}
