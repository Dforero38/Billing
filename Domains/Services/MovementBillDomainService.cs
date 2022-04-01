using Billing.Domain.Entity;
using Billing.Domains.Services.Contracts;
using Billing.Repositories.Contracts;
using System.Collections.Generic;

namespace Billing.Domains.Services
{
    public class MovementBillDomainService : IMovementBillDomainService
    {
        private readonly IMovementBillRepository _movementBillRepository;
        
        public MovementBillDomainService (IMovementBillRepository movementBillRepository)
        {
            _movementBillRepository = movementBillRepository;
        }
        public bool InsertMovementBill(MovementBill movementBill)
        {
            try
            {
                _movementBillRepository.InsertMovementBill(movementBill);
                return true;
            }
            catch 
            {

                return false;
            }
        }
        public MovementBill ConsultMovementBillByNumber()
        {
            try
            {
                return _movementBillRepository.ConsultMovementBillByNumber();
            }
            catch 
            {

                return new MovementBill();
            }
        }

        public List<MovementBill> ConsultMovementBills()
        {
            try
            {
                return _movementBillRepository.ConsultMovementBills();
            }
            catch
            {

                return new List<MovementBill>();
            }
        }

    }
}
