using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.BLL.Interfaces;

namespace PublishingHouse.Controllers
{
    public class OrderController : Controller
    {
        private IBookService _bookService;
        private List<BookPreviewDto> _books;

        public OrderController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task Add(int id)
        {
            _books.Add(await _bookService.GetOneBookPreviewAsync(id));
        }

        [HttpGet]
        public IActionResult Buy()
        {
            return View(_books);
        }

        //[HttpPost]
        //public Task<IActionResult> Buy(int id)
        //{
        //    return View();
        //}
    }
}