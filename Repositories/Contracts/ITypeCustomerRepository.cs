using Billing.Domain.Entity;
using System.Collections.Generic;

namespace Billing.Repositories.Contracts
{
    public interface ITypeCustomerRepository
    {
        List<TypeCustomer> GetTypeCustomers();
    }
}
