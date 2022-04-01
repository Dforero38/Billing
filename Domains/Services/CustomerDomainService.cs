using Billing.Domain.Entity;
using Billing.Domains.Services.Contracts;
using Billing.Repositories.Contracts;
using System.Collections.Generic;

namespace Billing.Domains.Services
{
    public class CustomerDomainService : ICustomerDomainService 
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITypeCustomerRepository _typecustomerRepository;

        public CustomerDomainService(ICustomerRepository customerRepository,
                                     ITypeCustomerRepository typecustomerRepository)
        {
            _customerRepository = customerRepository;
            _typecustomerRepository = typecustomerRepository;

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

        public bool DeleteCustomer ( int customerID)
        {
            try
            {
                _customerRepository.DeleteCustomer(customerID);
                return true;
            }
            catch
            {

                return false ;
            }
        }
        public List<TypeCustomer> GetTypeCustomer()
        {
            try
            {
                return _typecustomerRepository.GetTypeCustomers();
            }
            catch
            {
                return new List<TypeCustomer>();
            }
        }
    }
}
