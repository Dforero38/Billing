using Billing.Domain.Entity;
using System.Collections.Generic;

namespace Billing.Repositories.Contracts
{
    public interface IMovementBillRepository
    {
        MovementBill InsertMovementBill(MovementBill movementBill);
        MovementBill ConsultMovementBillByNumber();
        List<MovementBill> ConsultMovementBills();
    }
}
