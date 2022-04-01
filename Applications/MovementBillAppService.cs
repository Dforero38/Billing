using AutoMapper;
using Billing.Applications.Contracts;
using Billing.Domain.Entity;
using Billing.Domains.Services.Contracts;
using Billing.DTOs;
using System.Collections.Generic;

namespace Billing.Applications
{
    public class MovementBillAppService : IMovementBillAppService
    {
        private readonly IMovementBillDomainService _movementBillDomainService;
        private readonly IMapper _mapper;


        public MovementBillAppService(IMovementBillDomainService movementBillDomainService, IMapper mapper)
        {
            _movementBillDomainService = movementBillDomainService;
            _mapper = mapper;
        }
        public bool InsertMovementBill(CreateBillDTO createBillDTO)
        {
            try
            {
                MovementBill movementBillMap = _mapper.Map<CreateBillDTO, MovementBill>(createBillDTO);
                var result = _movementBillDomainService.InsertMovementBill(movementBillMap);
                return result;
            }
            catch (System.Exception exception)
            {

                throw exception;
            }
        }

        public MovementBillDTO ConsultMovementBillByNumber()
        {
            try
            {
               var movementBill = _movementBillDomainService.ConsultMovementBillByNumber();
                MovementBillDTO movementBillMap = _mapper.Map<MovementBill, MovementBillDTO>(movementBill);
                return movementBillMap;
            }
            catch (System.Exception exception)
            {

                throw exception;
            }
        }

        public List<BillingForPayDTO> ConsultMovementBills()
        {
            try
            {
                var movementBill = _movementBillDomainService.ConsultMovementBills();
                List<BillingForPayDTO> movementBillMap = _mapper.Map<List<MovementBill>, List<BillingForPayDTO>>(movementBill);
                return movementBillMap;
            }
            catch (System.Exception exception)
            {

                throw exception;
            }
        }
    }
}
