using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string ExistingImagePath { get; set; }

        [Required]
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Format { get; set; }
        [Required]
        public string Cover { get; set; }
        [Required]
        public int PagesAmount { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }

        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }       
        
    }
}
