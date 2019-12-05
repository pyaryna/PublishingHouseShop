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
    public class AuthorService: IAuthorService
    {
        private readonly IPublishingHouseUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(
            IPublishingHouseUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            IEnumerable<Author> authors = await _unitOfWork.Authors.GetAsync();

            return authors.Select(_mapper.Map<Author, AuthorDto>)
                .ToArray();
        }
        public async Task<AuthorDto> AddAuthorAsync(AddAuthorDto addAuthor)
        {
            var authorEntity = _unitOfWork.Authors.Add(_mapper.Map<AddAuthorDto, Author>(addAuthor));

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Author, AuthorDto>(authorEntity);
        }
    }
}
