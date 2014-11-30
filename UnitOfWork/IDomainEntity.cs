using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitOfWork
{
    public interface IDomainEntity
    {
        Guid Id { get; }
    }
}
