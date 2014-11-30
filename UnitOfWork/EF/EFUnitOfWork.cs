using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace UnitOfWork.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        DbContext context;
        DbContextTransaction transaction;
        public DbContext Context { get { return this.context; } }

        public EFUnitOfWork() 
        { 
            this.context = new ECommerceEntities();
        }

        public void OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (this.transaction == null)
            {
                this.transaction = this.context.Database.BeginTransaction(isolationLevel);
            }
        }

        public void Commit()
        {
            try
            {
                this.context.SaveChanges();
                this.transaction.Commit();
            }
            catch
            {
                this.transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            this.transaction.Rollback();
        }

        public void Dispose()
        {
            if(this.transaction != null)
            {
                this.transaction.Dispose();
                this.transaction = null;
            }

            this.context.Dispose();
        }
    }
}
