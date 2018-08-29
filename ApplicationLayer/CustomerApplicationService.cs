using DomainEntities;
using DomainService.Interfaces;
using DomainService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class CustomerApplicationService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly CustomerService _customerservice;
        public CustomerApplicationService(ICustomerRepository customerRepo, CustomerService customerservice)
        {
            _customerRepo = customerRepo;
            _customerservice = customerservice;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepo.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepo.GetCustomerById(id);
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepo.CreateCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepo.Update(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepo.Delete(id);
        }

    }
}
