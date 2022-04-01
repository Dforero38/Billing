using Billing.Domain.Entity;
using Billing.DTOs;
using System.Collections.Generic;

namespace Billing.Applications.Contracts
{
    public interface IMovementBillAppService
    {
        bool InsertMovementBill(CreateBillDTO createBillDTO);
        MovementBillDTO ConsultMovementBillByNumber();
        List<BillingForPayDTO> ConsultMovementBills();
    }
}
