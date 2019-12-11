using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.BLL.Interfaces;

namespace PublishingHouse.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddAuthorDto addAuthor)
        {
            if (ModelState.IsValid)
            {
                await _authorService.AddAuthorAsync(addAuthor);
                return RedirectToAction("authors", "admin");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.RemoveAuthorByIdAsync(id);
            return RedirectToAction("authors", "admin");
        }
    }
}