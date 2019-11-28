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

        public async Task<IEnumerable<Book>> GetAllBooksAsync(int? skip, int? take)
        {
            var dishes = GetBooksMainInfo();

            //if (skip.HasValue && take.HasValue)
            //{
            //    dishes = dishes.Paginate(skip.Value, take.Value);
            //}

            return await dishes.ToListAsync();
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
