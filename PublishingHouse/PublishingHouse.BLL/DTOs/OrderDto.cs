using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string DeliverAddress { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<CartDto> Carts { get; set; }
    }
}
