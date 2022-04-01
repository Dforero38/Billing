using Billing.Applications.Contracts;
using Billing.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Billing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController: ControllerBase
    {
        private readonly IPaymentAppService _paymentAppService; 

        public PaymentController (IPaymentAppService paymentAppService)
        {
            _paymentAppService = paymentAppService;
        }

        [HttpPost]
        [Route (nameof (PaymentController.InsertPayment))]
        public bool InsertPayment (PaymentDTO paymentDTO)
        {
            return _paymentAppService.InsertPayment(paymentDTO);
        }
    }
}
