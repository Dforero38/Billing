using Billing.Domain.Entity;
using System.Collections.Generic;

namespace Billing.Domains.Services.Contracts
{
    public interface IMovementProductDomainService
    {
        bool InsertMovementProduct(MovementProduct movementProduct);
        bool UpdateMovementProduct(MovementProduct movementProduct);
        List<MovementProduct> GetMovementProduct(int idMovementBill);
        bool DeleteMovementProduct(int movementProductID);
        MovementProduct GetMovementProductByID(int movementProductID);

    }
}
