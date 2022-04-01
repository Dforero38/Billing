using Billing.Domain.Entity;

namespace Billing.Repositories.Contracts
{
    public interface IPaymentRepository
    {
        void InsertPayment(Payment payment);
        void SavePayment();

    }
}
