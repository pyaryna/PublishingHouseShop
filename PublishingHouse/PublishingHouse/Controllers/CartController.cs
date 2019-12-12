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
    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<Customer> _userManager;

        public CartController(ICartService cartService, UserManager<Customer> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(int bookId)
        {
            AddCartDto addCart = new AddCartDto()
            {
                BookId = bookId,
                CustomerId = (await _userManager.GetUserAsync(HttpContext.User)).Id
            };
            await _cartService.AddCartAsync(addCart);

            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public async Task<IActionResult> Books()
        {
            var cart = await _cartService.GetCartForUserAsync((await _userManager.GetUserAsync(HttpContext.User)).Id);
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _cartService.RemoveCartByIdAsync(id);
            return RedirectToAction("books", "cart");
        }
    }
}