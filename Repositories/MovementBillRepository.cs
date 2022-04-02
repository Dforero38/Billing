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
        public void SumTotalMovementBill(int id, int value)
        {
            var findIdBill = _context.MovementBills.FirstOrDefault(first => first.Id.Equals(id));
            if (findIdBill != null)
            {
                findIdBill.SubTotal = findIdBill.SubTotal + value;
                findIdBill.Total = findIdBill.SubTotal + findIdBill.Iva;
                _context.Entry(findIdBill).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
        public void RestTotalMovementBill(int id, int value)
        {
            var findIdBill = _context.MovementBills.FirstOrDefault(first => first.Id.Equals(id));
            if (findIdBill != null)
            {
                findIdBill.SubTotal = findIdBill.SubTotal - value;
                _context.Entry(findIdBill).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
        public MovementBill GetMovementBillByID(int movementBillId)
        {
            return _context.MovementBills.Where(where => where.Id.Equals(movementBillId)).FirstOrDefault();
        }
    }
}
