using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.Extensions;
using PublishingHouse.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PublishingHouse.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private ICategoryService _categoryService;

        public BookController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetOneBookInfoAsync(id);
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AddBookDto book = await this.GetAddBookDto(_authorService, _categoryService);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBookDto addBook)
        {
            if (ModelState.IsValid)
            {
                var newBook = await _bookService.AddBookAsync(addBook);
                return RedirectToAction("Details", new { id = newBook.Id });
            }
            AddBookDto book = await this.GetAddBookDto(_authorService, _categoryService);

            return View(book);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var book = await this.GetUpdateBookDto(_bookService,_authorService, _categoryService, id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBookDto updateBook)
        {
            if (ModelState.IsValid)
            {
                var updatedBook = await _bookService.UpdateBookAsync(updateBook.Id, updateBook);
                return RedirectToAction("Details", new { id = updatedBook.Id });
            }

            var book = await this.GetUpdateBookDto(_bookService, _authorService, _categoryService, updateBook.Id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.RemoveBookByIdAsync(id);
            return View("~/Home/Index");
        }
    }
}
