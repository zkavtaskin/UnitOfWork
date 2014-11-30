using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWork;
using System.IO;
using UnitOfWork.EF;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("##NHibernate###");
            NHUnitOfWork uowNH = new NHUnitOfWork();
            CustomerService customerServiceNH = new CustomerService(uowNH, new NHRepository<Customer>(uowNH));
            
            try
            {
                CustomerDto customerDto = customerServiceNH.Add("NH First Name", Guid.NewGuid().ToString().Substring(0, 7));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                uowNH.Dispose();
            }


            System.Console.WriteLine("##Entity Framework###");
            EFUnitOfWork uowEF = new EFUnitOfWork();
            CustomerService customerServiceEF = new CustomerService(uowEF, new EFRepository<Customer>(uowEF));

            try
            {
                CustomerDto customerDto = customerServiceEF.Add("EF First Name", Guid.NewGuid().ToString().Substring(0, 7));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                uowEF.Dispose();
            }
        }
    }
}
