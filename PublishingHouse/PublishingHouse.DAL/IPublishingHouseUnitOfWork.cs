using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL
{
    public interface IPublishingHouseUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IBookAuthorRepository BookAuthors { get; }
        IBookCategoryRepository BookCategories { get; }
        IBookOrderRepository BookOrders { get; }
        IBookRepository Books { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IOrderRepository Orders { get; }

        Task CommitAsync();
    }
}
