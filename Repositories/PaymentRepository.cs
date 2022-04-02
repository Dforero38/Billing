using Billing.Domain.Entity;
using Billing.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Billing.Repositories
{
    public class PaymentRepository: IPaymentRepository
    {
        private readonly BillingContext _context;

        public PaymentRepository(BillingContext context)
        {
            _context = context;
        }
        public Payment GetPaymentByID(int paymentID)
        {
            return _context.Payments.Find(paymentID);
        }
        public void InsertPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public void SavePayment()
        {
            _context.SaveChanges();
        }


    }
}
