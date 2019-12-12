using PublishingHouse.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.BLL.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartDto>> GetCartForUserAsync(string id);

        Task AddCartAsync(AddCartDto addCart);

        Task RemoveCartByIdAsync(int id);
    }
}
