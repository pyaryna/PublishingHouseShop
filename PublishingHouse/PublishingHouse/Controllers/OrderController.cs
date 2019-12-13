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
        //public IActionResult Create(IEnumerable<CartDto> carts)
        //{
        //    OrderDto order = new OrderDto
        //    {
        //        Carts = carts.ToList()
        //    };
        //    return View(order);
        //}

        [HttpGet]
        public IActionResult Create(OrderDto order)
        {
            return View(order);
        }
       
    }
}