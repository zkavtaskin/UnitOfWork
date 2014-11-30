using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace UnitOfWork
{
    public class NHRepositoryAutoTransaction<TEntity> : IRepoistory<TEntity>
        where TEntity : IDomainEntity
    {
        readonly NHRepository<TEntity> repository;
        readonly NHUnitOfWork nhUnitOfWork;

        public NHRepositoryAutoTransaction(NHRepository<TEntity> repository, NHUnitOfWork nhUnitOfWork)
        {
            this.repository = repository;
            this.nhUnitOfWork = nhUnitOfWork;
        }

        public void Add(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();
            this.repository.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();
            this.repository.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();
            this.repository.Update(entity);
        }
        
        public IEnumerable<TEntity> GetAll()
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();
            return this.repository.GetAll();
        }
    }
}
