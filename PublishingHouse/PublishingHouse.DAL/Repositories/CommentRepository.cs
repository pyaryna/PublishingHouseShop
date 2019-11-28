using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Repositories
{
    public class CommentRepository : Repository<Comment, int>, ICommentRepository
    {
        public CommentRepository(PublishingHouseContext context) : base(context) { }
    }
}
