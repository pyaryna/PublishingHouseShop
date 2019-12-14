using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class BookOrderPreviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}
