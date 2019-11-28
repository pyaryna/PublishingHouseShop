﻿using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
    }
}
