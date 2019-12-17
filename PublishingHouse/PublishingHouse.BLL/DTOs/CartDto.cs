using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public BookPreviewDto Book { get; set; }

        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
    }
}
