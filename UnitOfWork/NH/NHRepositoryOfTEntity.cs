using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace UnitOfWork
{
    public class NHRepository<TEntity> : IRepoistory<TEntity>
        where TEntity : IDomainEntity
    {
        readonly NHUnitOfWork nhUnitOfWork;

        public NHRepository(NHUnitOfWork nhUnitOfWork)
        {
            this.nhUnitOfWork = nhUnitOfWork;
        }

        public void Add(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();
            this.nhUnitOfWork.Session.Save(entity);
        }

        public void Remove(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();
            this.nhUnitOfWork.Session.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();
            this.nhUnitOfWork.Session.Update(entity);
        }
        
        public IEnumerable<TEntity> GetAll()
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();
            return this.nhUnitOfWork.Session.Query<TEntity>();
        }
    }
}
