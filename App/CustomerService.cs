using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWork;

namespace Application
{
    public class CustomerService
    {
        readonly IUnitOfWork unitOfWork;
        readonly IRepoistory<Customer> repositoryCustomer;

        public CustomerService(IUnitOfWork uow, IRepoistory<Customer> repositoryCustomer)
        {
            this.unitOfWork = uow;
            this.repositoryCustomer = repositoryCustomer;
        }

        public CustomerDto Add(string firstName, string lastName)
        {
            int existingWithSameName = this.repositoryCustomer.GetAll()
                    .Count(customer => customer.FirstName == firstName && customer.LastName == lastName);

            if (existingWithSameName != 0)
                throw new NotImplementedException("User already exists with this name");

            Customer customerNew = new Customer(firstName, lastName);
            
            this.repositoryCustomer.Add(customerNew);
            this.unitOfWork.Commit();

            return new CustomerDto(customerNew.Id, customerNew.FirstName, customerNew.LastName);
        }
    }
}
