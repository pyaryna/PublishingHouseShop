using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book, int>
    {
        Task<Book> FindAsync(int key);
        Task<IEnumerable<Book>> GetAllBooksAsync(int? authorId, int? categoryId, bool sortByPrice, bool ascending, int? skip, int? take);
    }
}
