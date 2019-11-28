using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Entities
{
    public class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
