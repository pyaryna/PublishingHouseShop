using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Entities
{
    public class Order
    {
        public Order()
        {
            BookOrders = new HashSet<BookOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Deliver { get; set; }
        public string DeliverAddress { get; set; }
        public DateTime DateTime { get; set; }

        public ICollection<BookOrder> BookOrders { get; set; }
    }
}
