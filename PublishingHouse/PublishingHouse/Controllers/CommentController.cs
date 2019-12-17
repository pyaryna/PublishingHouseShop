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

        public CommentController(ICommentService commentService,
                                 UserManager<Customer> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(int bookId, AddCommentDto addComment)
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

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int bookId)
        {
            await _commentService.RemoveCommentByIdAsync(id);
            return RedirectToAction("details", "book", new { id = bookId });
        }
    }
}