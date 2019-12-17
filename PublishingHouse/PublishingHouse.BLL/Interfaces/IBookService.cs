﻿using PublishingHouse.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.BLL.Interfaces
{
    public interface IBookService
    {
#nullable enable
        Task<IEnumerable<BookPreviewDto>> GetAllBooksInfoAsync(PreviewDto? preview);
        Task<int> GetBooksCountAsunc();
        Task<BookDto> GetOneBookInfoAsync(int id);
        Task<BookPreviewDto> GetOneBookPreviewAsync(int id);
        Task<UpdateBookDto> GetBookForUpdateAsync(int id);
        Task<BookDto> AddBookAsync(AddBookDto addBook);
        Task<BookDto> UpdateBookAsync(int id, UpdateBookDto updateBook);
        Task RemoveBookByIdAsync(int id);
    }
}
