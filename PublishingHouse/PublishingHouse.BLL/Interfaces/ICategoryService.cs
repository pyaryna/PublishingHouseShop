﻿using PublishingHouse.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> AddCategoryAsync(AddCategoryDto addCategory);
        Task RemoveCategoryByIdAsync(int id);
    }
}
