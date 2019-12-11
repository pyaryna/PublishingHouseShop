using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Entities
{
   public class Book
    {
        public Book()
        {
            Carts = new HashSet<Cart>();
            Comments = new HashSet<Comment>();

            BookAuthors = new HashSet<BookAuthor>();
            BookCategories = new HashSet<BookCategory>();
            BookOrders = new HashSet<BookOrder>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Language { get; set; }
        public int Year { get; set; }
        public string Format { get; set; }
        public string Cover { get; set; }
        public int PagesAmount { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public ICollection<Cart> Carts { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<BookOrder> BookOrders { get; set; }
    }
}
