using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class CartDto
    {
        public BookPreviewDto Book { get; set; }
        public int Amount { get; set; }
        public int TotalSumPerBook { get; set; }
        public int TotalSum { get; set; }
    }
}
