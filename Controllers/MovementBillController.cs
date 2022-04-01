using Billing.Applications.Contracts;
using Billing.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Billing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementBillController : Controller
    {
        private readonly IMovementBillAppService _movementBillAppService;
        public MovementBillController(IMovementBillAppService movementBillAppService)
        {
            _movementBillAppService = movementBillAppService;
        }
        [HttpPost]
        [Route(nameof(MovementBillController.InsertMovementBill))]
        public bool InsertMovementBill(CreateBillDTO createBillDTO)
        {
            return _movementBillAppService.InsertMovementBill(createBillDTO);
        }

        [HttpGet]
        [Route(nameof(MovementBillController.ConsultMovementBillByNumber))]
        public MovementBillDTO ConsultMovementBillByNumber()
        {
            return _movementBillAppService.ConsultMovementBillByNumber();
        }

        [HttpGet]
        [Route(nameof(MovementBillController.ConsultMovementBills))]
        public List<BillingForPayDTO> ConsultMovementBills()
        {
            return _movementBillAppService.ConsultMovementBills();
        }
    }
}
