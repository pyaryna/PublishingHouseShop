using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}
