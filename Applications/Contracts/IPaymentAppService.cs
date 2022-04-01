using Billing.DTOs;

namespace Billing.Applications.Contracts
{
    public interface IPaymentAppService
    {
        bool InsertPayment(PaymentDTO collectionDTO);
    }
}
