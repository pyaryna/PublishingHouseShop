using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Repositories
{
    public class BookOrderRepository : Repository<BookOrder, int>, IBookOrderRepository
    {
        public BookOrderRepository(PublishingHouseContext context) : base(context) { }
    }
}
