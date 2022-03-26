using Billing.Domain.Entity;
using System.Collections.Generic;

namespace Billing.Domains.Services.Contracts
{
    public interface ICustomerDomainService
    {
        bool InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        List<Customer> GetCustomer();
    }
}
