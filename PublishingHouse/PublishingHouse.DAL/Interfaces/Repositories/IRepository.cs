using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Interfaces.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();

        TEntity Add(TEntity item);

        Task<int> CountAsync();

        void AddRange(IEnumerable<TEntity> items);

        void Remove(TEntity item);

        void RemoveRange(IEnumerable<TEntity> items);
    }
}
