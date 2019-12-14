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
    public class OrderService: IOrderService
    {
        private readonly IPublishingHouseUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(
            IPublishingHouseUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<BookPreviewDto>> GetAllBooksInfoAsync(PreviewDto preview)
        //{
        //    IEnumerable<Book> books = null;
        //    if (preview != null)
        //    {
        //        books = await _unitOfWork.Books.GetAllBooksAsync(preview.Request.AuthorId,
        //                                                                        preview.Request.CategoryId,
        //                                                                        preview.Request.SortByPrice,
        //                                                                        preview.Request.IsAscending,
        //                                                                        preview.Request.Skip,
        //                                                                        preview.Request.Take);
        //    }
        //    else
        //    {
        //        books = await _unitOfWork.Books.GetAllBooksAsync(null, null,
        //                                                                        false,
        //                                                                        false,
        //                                                                        null,
        //                                                                        null);
        //    }


        //    return books.Select(_mapper.Map<Book, BookPreviewDto>)
        //        .ToArray();
        //}
        //public async Task<BookDto> GetOneBookInfoAsync(int id)
        //{
        //    return _mapper.Map<Book, BookDto>(await _unitOfWork.Books.FindAsync(id));
        //}

        public async Task<OrderDto> GetOneOrderInfoAsync(int id)
        {
            return _mapper.Map<Order, OrderDto>(await _unitOfWork.Orders.FindAsync(id));
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersForUserAsync(string id)
        {
            IEnumerable<Order> orders = await _unitOfWork.Orders.GetUserCartsAsync(id);

            return orders.Select(_mapper.Map<Order, OrderDto>)
                .ToArray();
        }

        public async Task<OrderDto> AddOrderAsync(AddOrderDto addOrder)
        {
            var orderEntity = _unitOfWork.Orders.Add(_mapper.Map<AddOrderDto, Order>(addOrder));

            var bookOrders = addOrder.Carts.Select(
                x => new BookOrder
                { BookId = x.Book.Id, Order = orderEntity, Amount = x.Amount });

            _unitOfWork.BookOrders.AddRange(bookOrders);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Order, OrderDto>(orderEntity);
        }

        public async Task RemoveOrderByIdAsync(int id)
        {
            var order = await _unitOfWork.Orders.FindAsync(id);

            _unitOfWork.Orders.Remove(order);

            await _unitOfWork.CommitAsync();
        }
    }
}
