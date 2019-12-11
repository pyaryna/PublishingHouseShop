using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Repositories
{
    public class CartRepository : Repository<Cart, int>, ICartRepository
    {
        public CartRepository(PublishingHouseContext context) : base(context) { }
    }
}
