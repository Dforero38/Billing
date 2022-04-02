using Billing.Applications.Contracts;
using Billing.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Billing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementProductController : Controller
    {
        private readonly IMovementProductAppService _movementProductAppService;
        public MovementProductController(IMovementProductAppService movementProductAppService)
        {
            _movementProductAppService = movementProductAppService;
        }

        [HttpPost]
        [Route(nameof(MovementProductController.InsertMovementProduct))]
        public bool InsertMovementProduct (CreateMovementProductDTO movementProductDTO)
        {
            return _movementProductAppService.InsertMovementProduct(movementProductDTO);
        }

        [HttpPut]
        [Route(nameof(MovementProductController.UpdateMovementProduct))]
        public bool UpdateMovementProduct(CreateMovementProductDTO movementProductDTO)
        {
            return _movementProductAppService.UpdateMovementProduct(movementProductDTO);
        }

        [HttpGet]
        [Route(nameof(MovementProductController.GetMovementProduct))]
        public List<MovementProductDTO> GetMovementProduct(int idMovementBill)
        {
            return _movementProductAppService.GetMovementProduct(idMovementBill);
        }

        [HttpDelete]
        [Route(nameof(MovementProductController.DeleteMovementProduct))]
        public bool DeleteMovementProduct(int id)
        {
            return _movementProductAppService.DeleteMovementProduct(id);
        }
    }
}
