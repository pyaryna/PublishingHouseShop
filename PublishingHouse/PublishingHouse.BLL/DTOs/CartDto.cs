using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public BookPreviewDto Book { get; set; }
        public uint Amount { get; set; }
    }
}
