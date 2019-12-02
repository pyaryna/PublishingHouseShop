using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Interfaces.Repositories
{
    public interface IAuthorRepository: IRepository<Author, int>
    {
        Task<Author> FindAsync(int key);
    }
}
