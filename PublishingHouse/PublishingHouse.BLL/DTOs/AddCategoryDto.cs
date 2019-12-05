using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class AddCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
