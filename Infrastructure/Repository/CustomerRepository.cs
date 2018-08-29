using DomainService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;

namespace Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        public void CreateCustomer(Customer customer)
        {
            ApplicationContext.Customers.Add(customer);
        }

        public void Delete(int id)
        {
            ApplicationContext.DeleteCustomer(id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return ApplicationContext.Customers;
        }

        public Customer GetCustomerById(int id)
        {
            return ApplicationContext.Customers.Find(c => c.Id == id);
        }

        public void Update(Customer customer)
        {
            ApplicationContext.UpdateCustomer(customer);
        }
    }
}
