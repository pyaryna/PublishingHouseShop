using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book, int>
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(int? skip, int? take);
    }
}
