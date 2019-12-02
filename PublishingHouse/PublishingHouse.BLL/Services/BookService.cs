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
    public class BookService: IBookService
    {
        private readonly IPublishingHouseUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(
            IPublishingHouseUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookPreviewDto>> GetAllBooksInfoAsync()
        {
            IEnumerable<Book> books = await _unitOfWork.Books.GetAllBooksAsync(null, null);

            return books.Select(_mapper.Map<Book, BookPreviewDto>)
                .ToArray();            
        }
        public async Task<BookDto> GetOneBookInfoAsync(int id) 
        {
            return _mapper.Map<Book, BookDto>(await _unitOfWork.Books.FindAsync(id));
        }
    }
}
