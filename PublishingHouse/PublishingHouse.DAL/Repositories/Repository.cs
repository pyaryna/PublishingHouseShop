using Microsoft.EntityFrameworkCore;
using PublishingHouse.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly PublishingHouseContext Context;

        public Repository(PublishingHouseContext context) => Context = context;

        public virtual TEntity Add(TEntity item) =>
            Context.Set<TEntity>()
                .Add(item)
                .Entity;

        public async Task<int> CountAsync() =>
            await Context.Set<TEntity>()
                .CountAsync();

        public virtual void AddRange(IEnumerable<TEntity> items)
        {
            Context.Set<TEntity>()
                .AddRange(items);
        }

        public virtual void Remove(TEntity item)
        {
            Context.Set<TEntity>()
                .Remove(item);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> items)
        {
            Context.Set<TEntity>()
                .RemoveRange(items);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync() =>
            await Context.Set<TEntity>()
                .ToListAsync();
    }
}
