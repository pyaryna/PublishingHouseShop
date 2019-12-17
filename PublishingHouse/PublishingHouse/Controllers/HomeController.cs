using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.BLL.Interfaces;
using PublishingHouse.Models;

namespace PublishingHouse.Controllers
{
    public class HomeController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private ICategoryService _categoryService;
        private INotificationService _notificationService;
        public HomeController(IBookService bookService, 
                                IAuthorService authorService, 
                                ICategoryService categoryService,
                                INotificationService notificationService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            PreviewDto preview = new PreviewDto();
            var count = await _bookService.GetBooksCountAsunc();
            var take = 8;
            preview.Request = new BLL.Request.BookRequest(null, null, false, false, count, page, take);
            preview.Books = await _bookService.GetAllBooksInfoAsync(preview);            
            preview.Categories = (await _categoryService.GetAllCategoriesAsync())
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.Id == preview.Request.CategoryId
                });
            preview.Authors = (await _authorService.GetAllAuthorsAsync())
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.Id == preview.Request.AuthorId
                });
            return View(preview);
        }

        [HttpPost]
        public async Task<IActionResult> Index(PreviewDto preview, int page = 1)
        {
            var count = await _bookService.GetBooksCountAsunc();
            var take = 8;
            preview.Request = new BLL.Request.BookRequest(preview.Request.AuthorId,
                                                preview.Request.CategoryId, 
                                                preview.Request.SortByPrice, preview.Request.IsAscending, 
                                                count, page, take);
            if (preview.Sorting == 0)
            {
                preview.Request.SortByPrice = false;
            }
            else if (preview.Sorting == 1)
            {
                preview.Request.SortByPrice = true;
                preview.Request.IsAscending = true;
            }
            else
            {
                preview.Request.SortByPrice = true;
                preview.Request.IsAscending = false;
            }
            preview.Books = await _bookService.GetAllBooksInfoAsync(preview);
            preview.Categories = (await _categoryService.GetAllCategoriesAsync())
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.Id == preview.Request.CategoryId
                });
            preview.Authors = (await _authorService.GetAllAuthorsAsync())
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.Id == preview.Request.AuthorId
                });
            return View(preview);
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCallback(CallbackDto callback)
        {
            if (ModelState.IsValid)
            {
                await _notificationService.AddNotificationAsync(callback);
                return View("Contacts");
            }                        
            return View();
        }

        [HttpGet]
        public IActionResult Design()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Druk()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Main()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Publishing()
        {
            return View();
        }










        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
