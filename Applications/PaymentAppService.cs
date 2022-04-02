using AutoMapper;
using Billing.Applications.Contracts;
using Billing.Domain.Entity;
using Billing.Domains.Services.Contracts;
using Billing.DTOs;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace Billing.Applications
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IPaymentDomainService _collectionDomainservice;
        private readonly IMapper _mapper;
        private readonly IMovementBillDomainService _movementBillDomainService;

        public PaymentAppService (IPaymentDomainService collectionDomainService, IMapper mapper, IMovementBillDomainService movementBillDomainService)
        {
           _collectionDomainservice = collectionDomainService;
           _mapper = mapper;
           _movementBillDomainService = movementBillDomainService;
        }
        public bool InsertPayment(PaymentDTO paymentDTO)
        {
            try
            {
                var bill = _movementBillDomainService.GetMovementBillByID(paymentDTO.idBill);
                paymentDTO.IdCustomer = bill.IdCustomer;
                Payment paymentMap = _mapper.Map<PaymentDTO, Payment>(paymentDTO);
                var result = _collectionDomainservice.InsertPayment(paymentMap);
                if (result)
                {
                    MovementBill movementBill = new MovementBill()
                    {
                        IdCustomer = paymentDTO.IdCustomer,
                        IdTransactionType = paymentDTO.TypePay,
                        NumberBill = paymentDTO.idBill,
                        Date = paymentDTO.Date,
                        Total = paymentDTO.Value
                    };
                var result1 = _movementBillDomainService.InsertMovementBill(movementBill);
                result = result1;
                }

                return result;
            }
            catch (System.Exception exception)
            {

                throw exception;
            }
        }
    }


}
