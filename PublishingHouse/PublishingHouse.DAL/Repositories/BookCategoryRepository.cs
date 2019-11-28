using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Repositories
{
    public class BookCategoryRepository : Repository<BookCategory, int>, IBookCategoryRepository
    {
        public BookCategoryRepository(PublishingHouseContext context) : base(context) { }
    }
}
