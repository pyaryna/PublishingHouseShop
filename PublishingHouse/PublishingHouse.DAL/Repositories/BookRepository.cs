using Microsoft.EntityFrameworkCore;
using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Repositories
{
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        public BookRepository(PublishingHouseContext context) : base(context) { }

        public async Task<Book> FindAsync(int id)
        {
            return await Context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Include(b => b.BookOrders)
                .ThenInclude(bo => bo.Order)
                .Include(b => b.Comments)
                .ThenInclude(c => c.Customer)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(int? authorId, int? categoryId, bool sortByPrice, bool ascending, int page)
        {
            var pageSize = 8;
            var books = GetBooksMainInfo();

            if (authorId.HasValue)
            {
                books = books.Where(b => b.BookAuthors.Any(ba => ba.AuthorId == authorId));
            }

            if (categoryId.HasValue)
            {
                books = books.Where(b => b.BookCategories.Any(bc => bc.CategoryId == categoryId));
            }

            if(sortByPrice == true)
            {
                books = ascending ? books.OrderBy(b => b.Price) : books.OrderByDescending(b => b.Price);
            }

            books = books.Skip((page - 1) * pageSize).Take(pageSize);

            return await books.ToListAsync();
        }

        private IQueryable<Book> GetBooksMainInfo()
        {
            return Context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)                
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Include(b => b.BookOrders)
                .ThenInclude(bo => bo.Order)
                .Include(b => b.Comments)
                .AsQueryable();
        }
    }
}
