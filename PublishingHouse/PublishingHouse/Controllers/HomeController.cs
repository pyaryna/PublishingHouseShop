using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MimeKit;
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
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            PreviewDto preview = new PreviewDto();
            preview.Books = await _bookService.GetAllBooksInfoAsync(null);
            preview.Request = new BLL.Request.BookRequest();
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
        public async Task<IActionResult> Index(PreviewDto preview)
        {
            if(preview.Sorting == 0)
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
        public IActionResult Contacts(CallbackDto callbackDto)
        {
            

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
