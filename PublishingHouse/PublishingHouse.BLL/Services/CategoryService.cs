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
    public class CategoryService: ICategoryService
    {
        private readonly IPublishingHouseUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(
            IPublishingHouseUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            IEnumerable<Category> categories = await _unitOfWork.Categories.GetAsync();

            return categories.Select(_mapper.Map<Category, CategoryDto>)
                .ToArray();
        }
        public async Task<CategoryDto> AddCategoryAsync(AddCategoryDto addCategory)
        {
            var categoryEntity = _unitOfWork.Categories.Add(_mapper.Map<AddCategoryDto, Category>(addCategory));

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Category, CategoryDto>(categoryEntity);
        }
        public async Task RemoveCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.FindAsync(id);

            _unitOfWork.Categories.Remove(category);

            await _unitOfWork.CommitAsync();
        }
    }
}
