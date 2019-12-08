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
    public class CommentRepository : Repository<Comment, int>, ICommentRepository
    {
        public CommentRepository(PublishingHouseContext context) : base(context) { }

        public async Task<Comment> FindAsync(int id)
        {
            return await Context.Comments
                //.Include(c => c.Book)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsByBookIdAsync(int bookId)
        {
            return await Context.Comments
                .Include(c => c.Book)
                .Where(x => x.BookId == bookId)
                .ToListAsync();
        }
    }
}
