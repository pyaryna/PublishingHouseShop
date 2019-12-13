using Microsoft.AspNetCore.Mvc.Rendering;
using PublishingHouse.BLL.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class PreviewDto
    {
        public IEnumerable<BookPreviewDto> Books { get; set; }
        public BookRequest Request { get; set; }

        public int Sorting { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
