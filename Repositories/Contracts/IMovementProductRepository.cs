using Billing.Domain.Entity;
using System.Collections.Generic;

namespace Billing.Repositories.Contracts
{
    public interface IMovementProductRepository
    {
        List<MovementProduct> GetMovementProducts();
        MovementProduct GetMovementProductByID(int movementProductId);
        void InsertMovementProduct(MovementProduct movementProduct);
        void DeleteMovementProduct(int movementProductID);
        void UpdateMovementProduct(MovementProduct movementProducts);
        public void SaveMovementProduct();

    }
}
