using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.BLL.Interfaces;
using PublishingHouse.DAL;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.BLL.Services
{
    public class CartService: ICartService
    {
        private readonly IPublishingHouseUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(
            IPublishingHouseUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartDto>> GetCartForUserAsync(string id)
        {
            IEnumerable<Cart> carts = await _unitOfWork.Carts.GetUserCartsAsync(id);

            return carts.Select(_mapper.Map<Cart, CartDto>)
                .ToArray();
        }

        public async Task AddCartAsync(AddCartDto addCart)
        {
            _unitOfWork.Carts.Add(_mapper.Map<AddCartDto, Cart>(addCart));

            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveBookByIdAsync(int bookId, string customerId)
        {
            var cart = await _unitOfWork.Carts.FindAsync(bookId, customerId);

            _unitOfWork.Carts.Remove(cart);

            await _unitOfWork.CommitAsync();
        }
    }
}
