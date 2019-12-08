using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
        Task<Comment> FindAsync(int key);
        Task<IEnumerable<Comment>> GetAllCommentsByBookIdAsync(int bookId);
    }
}
