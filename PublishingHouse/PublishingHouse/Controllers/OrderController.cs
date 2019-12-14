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
        private UserManager<Customer> _userManager;

        public OrderController(IOrderService orderService, UserManager<Customer> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        //[HttpGet]
        //public IActionResult Create(OrderDto order)
        //{
        //    return View(order);
        //}

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
                var newOrder = await _orderService.AddOrderAsync(addOrder);
                return RedirectToAction("Details", new { id = newOrder.Id });
            }

            return RedirectToAction("create", "order", new { carts = addOrder.Carts });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetOneOrderInfoAsync(id);
            return View(order);
        }
    }
}