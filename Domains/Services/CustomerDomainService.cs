using Billing.Domain.Entity;
using Billing.Domains.Services.Contracts;
using Billing.Repositories.Contracts;
using System.Collections.Generic;

namespace Billing.Domains.Services
{
    public class CustomerDomainService : ICustomerDomainService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerDomainService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public bool InsertCustomer(Customer customer)
        {
            try
            {
                _customerRepository.InsertCustomer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                _customerRepository.UpdateCustomer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Customer> GetCustomer()
        {
            try
            {
                return  _customerRepository.GetCustomers();
            }
            catch
            {
                return new List<Customer>() ;
            }
        }
    }
}
