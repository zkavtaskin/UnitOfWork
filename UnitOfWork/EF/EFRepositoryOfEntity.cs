using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitOfWork.EF
{
    public class EFRepository<TEntity> : IRepoistory<TEntity>
        where TEntity : class, IDomainEntity
    {
        readonly EFUnitOfWork unitOfWork;

        public EFRepository(EFUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(TEntity entity)
        {
            this.unitOfWork.OpenTransaction();
            this.unitOfWork.Context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            this.unitOfWork.OpenTransaction();
            this.unitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            this.unitOfWork.OpenTransaction();
            return this.unitOfWork.Context.Set<TEntity>().ToList();
        }
    }
}
