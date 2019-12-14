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
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private ICartService _cartService;
        private UserManager<Customer> _userManager;

        public OrderController(IOrderService orderService, ICartService cartService, UserManager<Customer> userManager)
        {
            _orderService = orderService;
            _cartService = cartService;
            _userManager = userManager;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Create(IEnumerable<CartDto> carts)
        {
            AddOrderDto order = new AddOrderDto
            {
                Carts = carts.ToList()
            };
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddOrderDto addOrder)
        {
            if (ModelState.IsValid)
            {
                addOrder.DateTime = DateTime.Now;
                addOrder.CustomerId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
                var newOrder = await _orderService.AddOrderAsync(addOrder);

                foreach(var cart in addOrder.Carts)
                {
                    await _cartService.RemoveCartByIdAsync(cart.Id);
                }

                return RedirectToAction("Details", new { id = newOrder.Id });
            }

            return RedirectToAction("create", "order", new { carts = addOrder.Carts });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetOneOrderInfoAsync(id);
            order.TotalSum = order.Books.Sum(b => b.Amount * b.Price);
            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> OrdersForUser()
        {
            var orders = (await _orderService.GetOrdersForUserAsync((
                                await _userManager.GetUserAsync(HttpContext.User)).Id))
                                .ToList();
            return View(orders);
        }
    }
}