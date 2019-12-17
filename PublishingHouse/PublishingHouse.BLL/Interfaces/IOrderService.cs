﻿using PublishingHouse.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersInfoAsync();
        Task<OrderDto> GetOneOrderInfoAsync(int id);
        Task<IEnumerable<OrderDto>> GetOrdersForUserAsync(string id);
        Task<OrderDto> AddOrderAsync(AddOrderDto addOrder);
        Task RemoveOrderByIdAsync(int id);
    }
}
