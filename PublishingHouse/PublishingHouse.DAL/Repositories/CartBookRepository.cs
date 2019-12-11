using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Repositories
{
    public class CartBookRepository : Repository<CartBook, int>, ICartBookRepository
    {
        public CartBookRepository(PublishingHouseContext context) : base(context) { }
    }
}
