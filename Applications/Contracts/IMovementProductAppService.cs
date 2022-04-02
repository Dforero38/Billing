using Billing.DTOs;
using System.Collections.Generic;

namespace Billing.Applications.Contracts
{
    public interface IMovementProductAppService
    {
        bool InsertMovementProduct(CreateMovementProductDTO movementProductDTO);
        bool UpdateMovementProduct(CreateMovementProductDTO movementProductDTO);
        List<MovementProductDTO> GetMovementProduct(int idMovementBill);
        bool DeleteMovementProduct(int movementProductID);


    }
}
