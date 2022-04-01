using Billing.DTOs;
using System.Collections.Generic;

namespace Billing.Applications.Contracts
{
    public interface IMovementProductAppService
    {
        bool InsertMovementProduct(MovementProductDTO movementProductDTO);
        bool UpdateMovementProduct(MovementProductDTO movementProductDTO);
        List<MovementProductDTO> GetMovementProduct();
        bool DeleteMovementProduct(int movementProductID);


    }
}
