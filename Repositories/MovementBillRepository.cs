using Billing.Domain.Entity;
using Billing.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Billing.Repositories
{
    public class MovementBillRepository : IMovementBillRepository
    {
        private readonly BillingContext _context;

        public MovementBillRepository(BillingContext context)
        {
            _context = context;
        }
        public MovementBill InsertMovementBill (MovementBill movementBill)
        {
            _context.MovementBills.Add(movementBill);
            _context.SaveChanges();
            return movementBill;
        }
        public MovementBill ConsultMovementBillByNumber ()
        {
            return _context.MovementBills.OrderByDescending(order => order.Id).Include(include => include.IdCustomerNavigation).FirstOrDefault();
            
        }
        public List<MovementBill> ConsultMovementBills()
        {
            return _context.MovementBills.Include(include => include.IdCustomerNavigation).ToList();
        }

    }
}
