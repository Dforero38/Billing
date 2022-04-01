using Billing.Domain.Entity;
using System.Collections.Generic;

namespace Billing.Domains.Services.Contracts
{
    public interface IMovementProductDomainService
    {
        bool InsertMovementProduct(MovementProduct movementProduct);
        bool UpdateMovementProduct(MovementProduct movementProduct);
        List<MovementProduct> GetMovementProduct();
        bool DeleteMovementProduct(int movementProductID);

    }
}
