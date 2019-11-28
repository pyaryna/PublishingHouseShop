using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Entities
{
    public class Category
    {
        public Category()
        {
            BookCategories = new HashSet<BookCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
