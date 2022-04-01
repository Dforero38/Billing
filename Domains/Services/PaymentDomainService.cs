using Billing.Domain.Entity;
using Billing.Domains.Services.Contracts;
using Billing.Repositories.Contracts;

namespace Billing.Domains.Services
{
    public class PaymentDomainService : IPaymentDomainService
    {
        private readonly IPaymentRepository _paymentRepository;


        public PaymentDomainService(IPaymentRepository collectionRepository)
        {
            _paymentRepository = collectionRepository;
        }
        public bool InsertPayment(Payment payment)
        {
            try
            {
                _paymentRepository.InsertPayment(payment);
                return true;
            }
            catch 
            {

                return false;
            }
        }
    }
}
