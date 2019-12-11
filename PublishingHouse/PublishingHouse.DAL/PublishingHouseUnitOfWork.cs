using PublishingHouse.DAL.Interfaces.Repositories;
using PublishingHouse.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL
{
    public class PublishingHouseUnitOfWork: IPublishingHouseUnitOfWork
    {
        private readonly PublishingHouseContext _context;

        public PublishingHouseUnitOfWork(PublishingHouseContext context)
        {
            _context = context;

            Authors = new AuthorRepository(_context);
            BookAuthors = new BookAuthorRepository(_context);
            BookCategories = new BookCategoryRepository(_context);
            BookOrders = new BookOrderRepository(_context);
            Books = new BookRepository(_context);
            CartBooks = new CartBookRepository(_context);
            Carts = new CartRepository(_context);
            Categories = new CategoryRepository(_context);
            Comments = new CommentRepository(_context);
            Orders = new OrderRepository(_context);           
        }

        public IAuthorRepository Authors { get; }
        public IBookAuthorRepository BookAuthors { get; }
        public IBookCategoryRepository BookCategories { get; }
        public IBookOrderRepository BookOrders { get; }
        public IBookRepository Books { get; }
        public ICartBookRepository CartBooks { get; }
        public ICartRepository Carts { get; }
        public ICategoryRepository Categories { get; }
        public ICommentRepository Comments { get; }
        public IOrderRepository Orders { get; }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }        
    }
}
