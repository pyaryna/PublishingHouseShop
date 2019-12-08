using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class AddCommentDto
    {
        [Required]
        public string Text { get; set; }
        public int BookId { get; set; }
        public string CustomerId { get; set; }
    }
}
