using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.BLL.Interfaces;
using PublishingHouse.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PublishingHouse.Extensions
{
    public static class BookControllerExtensions
    {
        public static async Task<AddBookDto> GetAddBookDto(this BookController bookController, IAuthorService authorService, ICategoryService categoryService)
        {
            AddBookDto book = new AddBookDto();
            book.Categories = (await categoryService.GetAllCategoriesAsync())
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.Id == book.CategoryId
                });
            book.Authors = (await authorService.GetAllAuthorsAsync())
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.Id == book.AuthorId
                });
            return book;
        }
        public static async Task<UpdateBookDto> GetUpdateBookDto(
            this BookController bookController,
            IBookService bookService,
            IAuthorService authorService, 
            ICategoryService categoryService,
            int id)
        {
            UpdateBookDto book =  await bookService.GetBookForUpdateAsync(id);
            book.Categories = (await categoryService.GetAllCategoriesAsync())
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.Id == book.CategoryId
                });
            book.Authors = (await authorService.GetAllAuthorsAsync())
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.Id == book.AuthorId
                });
            return book;
        }
    }
}
