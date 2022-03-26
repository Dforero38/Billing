using Billing.Applications.Contracts;
using Billing.Domain.Entity;
using Billing.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {    
        private readonly ICustomerAppService _customerAppService;
        public CustomersController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpPost]
        [Route(nameof(CustomersController.InsertCustomer))]
        public bool InsertCustomer(CustomerDTO customerDTO)
        {
            return _customerAppService.InsertCustomer(customerDTO);
        }

        [HttpPut]
        [Route(nameof(CustomersController.UpdateCustomer))]
        public bool UpdateCustomer(CustomerDTO customerDTO)
        {
            return _customerAppService.UpdateCustomer(customerDTO);
        }

        [HttpGet]
        [Route(nameof(CustomersController.GetCustomer))]
        public List<CustomerDTO> GetCustomer()
        {
            return _customerAppService.GetCustomer();
        }
    }
}
