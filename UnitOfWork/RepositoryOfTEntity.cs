using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitOfWork
{
    public interface IRepoistory<TEntity>
        where TEntity : IDomainEntity
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}
