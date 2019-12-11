using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Entities
{
    public class Cart
    {
        public Cart()
        {
            CartBooks = new HashSet<CartBook>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<CartBook> CartBooks { get; set; }
    }
}
