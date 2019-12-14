using PublishingHouse.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOneOrderInfoAsync(int id);
        Task<OrderDto> AddOrderAsync(AddOrderDto addOrder);
        Task RemoveOrderByIdAsync(int id);
    }
}
