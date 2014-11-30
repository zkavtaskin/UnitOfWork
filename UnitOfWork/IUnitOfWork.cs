using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
