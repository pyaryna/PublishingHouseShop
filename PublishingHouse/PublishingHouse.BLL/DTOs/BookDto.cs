using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class BookDto
    {
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

        public ICollection<CommentDto> Comments { get; set; }

        public ICollection<AuthorDto> Authors { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }
    }
}
