using Billing.Domain.Entity;
using Billing.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Billing.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BillingContext _context;

        public CustomerRepository(BillingContext context)
        {
            _context = context;
        }
        public List<Customer> GetCustomers()
        {
            return _context.Customers.Include(include => include.IdTypeCustomerNavigation).ToList();
        }

        public Customer GetCustomerByID(int costumerId)
        {
            return _context.Customers.Find(costumerId);
        }

        public void InsertCustomer(Customer costumer)
        {
            _context.Customers.Add(costumer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int customerID)
        {
            Customer costumer = _context.Customers.Find(customerID);
            _context.Customers.Remove(costumer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer costumer)
        {
            _context.Entry(costumer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void SaveCustomer()
        {
            _context.SaveChanges();
        }
    }
}
