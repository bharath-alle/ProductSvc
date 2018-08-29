using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Interfaces
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);

    }
}
