using Billing.Domain.Entity;

namespace Billing.Domains.Services.Contracts
{
    public interface IPaymentDomainService
    {
        bool InsertPayment(Payment payment);
    }
}
