using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Repositories
{
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        public BookRepository(PublishingHouseContext context) : base(context) { }
    }
}
