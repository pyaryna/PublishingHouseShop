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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private ICategoryService _categoryService;
        private IOrderService _orderService;
        private INotificationService _notificationService;
        private UserManager<Customer> _userManager;

        public AdminController(IBookService bookService, 
                                IAuthorService authorService, 
                                ICategoryService categoryService,
                                IOrderService orderService,
                                INotificationService notificationService,
                                UserManager<Customer> userManager)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _orderService = orderService;
            _notificationService = notificationService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Books(int page = 1)
        {
            PreviewDto preview = new PreviewDto();
            var count = await _bookService.GetBooksCountAsunc();
            var take = 8;
            preview.Request = new BLL.Request.BookRequest(null, null, false, false, count, page, take);
            preview.Books = await _bookService.GetAllBooksInfoAsync(preview);
            return View(preview);
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
            foreach (var order in orders)
            {
                order.TotalSum = order.Books.Sum(b => b.Amount * b.Price);
            }
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Notices()
        {
            var notices = (await _notificationService.GetAllNotificationsInfoAsync()).ToList();
            return View(notices);
        }

        [HttpGet]
        public async Task<IActionResult> NoticeDetails(int id)
        {
            var notice = await _notificationService.GetOneNotificationInfoAsync(id);
            return View(notice);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNotice(int id)
        {
            await _notificationService.RemoveNotificationByIdAsync(id);
            return RedirectToAction("Notices", "admin");
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