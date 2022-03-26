using Billing.DTOs;
using System.Collections.Generic;

namespace Billing.Applications.Contracts
{
    public interface ICustomerAppService
    {
        bool InsertCustomer(CustomerDTO customerDTO);
        bool UpdateCustomer(CustomerDTO customerDTO);
        List<CustomerDTO> GetCustomer();
    }
}
