using Billing.Domain.Entity;
using System.Collections.Generic;

namespace Billing.Domains.Services.Contracts
{
    public interface IMovementBillDomainService
    {
        bool InsertMovementBill(MovementBill movementBill);
        MovementBill ConsultMovementBillByNumber();
        List<MovementBill> ConsultMovementBills();
        bool SumTotalMovementBill(int id, int value);
        bool RestTotalMovementBill(int id, int value);
        MovementBill GetMovementBillByID(int movementBillID);
    }
}
