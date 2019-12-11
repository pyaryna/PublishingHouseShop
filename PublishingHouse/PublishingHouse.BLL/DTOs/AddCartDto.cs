using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class AddCartDto
    {
        public int BookId { get; set; }
        public string CustomerId { get; set; }
    }
}
