using Billing.Domain.Entity;
using Billing.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Billing.Repositories
{
    public class TypeCustomerRepository : ITypeCustomerRepository
    {
        private readonly BillingContext _context;

        public TypeCustomerRepository(BillingContext context)
        {
            _context = context;
        }
        public List<TypeCustomer> GetTypeCustomers()
        {
            return _context.TypeCustomers.ToList();
        }
    }
}
