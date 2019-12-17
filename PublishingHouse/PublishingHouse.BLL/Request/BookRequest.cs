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
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }

        public BookRequest(){}

        public BookRequest(int? authorId, int? categoryId, 
                            bool sortByPrice, bool isAscending, int count, int pageNumber, int pageSize)
        {
            AuthorId = authorId;
            CategoryId = categoryId;
            SortByPrice = sortByPrice;
            IsAscending = isAscending;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
