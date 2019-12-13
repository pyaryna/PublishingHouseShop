using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.Request
{
    public class BookRequest
    {
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public bool SortByPrice { get; set; }
        public bool IsAscending { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
