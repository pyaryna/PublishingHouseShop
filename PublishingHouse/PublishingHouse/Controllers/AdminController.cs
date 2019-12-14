using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PublishingHouse.BLL.Interfaces;
using PublishingHouse.DAL.Entities;

namespace PublishingHouse.Controllers
{
    public class AdminController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private ICategoryService _categoryService;
        private IOrderService _orderService;
        private UserManager<Customer> _userManager;

        public AdminController(IBookService bookService, 
                                IAuthorService authorService, 
                                ICategoryService categoryService,
                                IOrderService orderService,
                                UserManager<Customer> userManager)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Books()
        {
            var books = await _bookService.GetAllBooksInfoAsync(null);
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Authors()
        {
            var books = await _authorService.GetAllAuthorsAsync();
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var books = await _categoryService.GetAllCategoriesAsync();
            return View(books);
        }

        [HttpGet]
        public IActionResult Customers()
        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var orders = (await _orderService.GetAllOrdersInfoAsync()).ToList();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Notices()
        {
            var notices = _userManager.Users;
            return View(notices);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Customers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("Customers");
            }
        }
    }
}