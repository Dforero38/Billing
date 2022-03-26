using Billing.Domain.Entity;
using System.Collections.Generic;

namespace Billing.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomerByID(int customerId);
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int customerID);
        void UpdateCustomer(Customer customer);
        void SaveCustomer();
    }
}
