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
        private IBookService _bookService;
        private UserManager<Customer> _userManager;

        public OrderController(IBookService bookService, UserManager<Customer> userManager)
        {
            _bookService = bookService;
            _userManager = userManager;
        }        

        [HttpGet]
        public IActionResult Buy()
        {
            return View();
        }

        //[HttpPost]
        //public Task<IActionResult> Buy(int id)
        //{
        //    return View();
        //}
    }
}