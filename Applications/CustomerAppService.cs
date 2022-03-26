using AutoMapper;
using Billing.Applications.Contracts;
using Billing.Domain.Entity;
using Billing.Domains.Services.Contracts;
using Billing.DTOs;
using System.Collections.Generic;

namespace Billing.Applications
{
    public class CustomerAppService: ICustomerAppService
    {
        private readonly ICustomerDomainService _customerDomainService;
        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerDomainService customerDomainService, IMapper mapper)
        {
            _customerDomainService = customerDomainService;
            _mapper = mapper;
        }
        public bool InsertCustomer(CustomerDTO customerDTO)
        {
            try
            {
                Customer customerMap = _mapper.Map<CustomerDTO, Customer>(customerDTO);
                var result = _customerDomainService.InsertCustomer(customerMap);
                return result;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        public bool UpdateCustomer(CustomerDTO customerDTO)
        {
            try
            {
                Customer customerMap = _mapper.Map<CustomerDTO, Customer>(customerDTO);
                var result = _customerDomainService.UpdateCustomer(customerMap);
                return result;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        public List<CustomerDTO> GetCustomer()
        {
            try
            {
                var result = _customerDomainService.GetCustomer();
                List<CustomerDTO> customer = _mapper.Map<List<Customer>, List<CustomerDTO>>(result);             
                return customer;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }
    }
}
