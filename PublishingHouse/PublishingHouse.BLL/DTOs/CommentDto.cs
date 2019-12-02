using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}
