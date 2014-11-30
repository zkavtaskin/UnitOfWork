using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWork;

namespace Application.Console
{
    public class Customer : IDomainEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public Customer()
        {
           
        }

        public Customer(string firstName, string lastName)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
