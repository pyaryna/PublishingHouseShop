using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.BLL.Interfaces;
using PublishingHouse.DAL.Entities;

namespace PublishingHouse.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private ICommentService _commentService;
        private UserManager<Customer> _userManager;
        private SignInManager<Customer> _signInManager;

        public CommentController(ICommentService commentService,
                                 UserManager<Customer> userManager,
                                 SignInManager<Customer> signInManager)
        {
            _commentService = commentService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(int bookId, int customerId, AddCommentDto addComment)
        {
            if (ModelState.IsValid)
            {
                addComment.BookId = bookId;
                addComment.CustomerId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
                await _commentService.AddCommentAsync(addComment);
                return RedirectToAction("details", "book", new { id = bookId });
            }

            return View();
        }


        //[HttpGet]
        //public async Task<IActionResult> Update(int id)
        //{
        //    var book = await this.GetUpdateBookDto(_bookService, _authorService, _categoryService, id);
        //    return View(book);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(UpdateBookDto updateBook)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var updatedBook = await _bookService.UpdateBookAsync(updateBook.Id, updateBook);
        //        return RedirectToAction("Details", new { id = updatedBook.Id });
        //    }

        //    var book = await this.GetUpdateBookDto(_bookService, _authorService, _categoryService, updateBook.Id);
        //    return View(book);
        //}

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int bookId)
        {
            await _commentService.RemoveCommentByIdAsync(id);
            return RedirectToAction("details", "book", new { id = bookId });
        }
    }
}