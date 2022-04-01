using System;

namespace Billing.DTOs
{
    public class CustomerDTO
    {
        public int? Id { get; set; }
        public int IdTypeCustomer { get; set; }
        public string DescriptionTypeCustomer { get; set; }
        public string BusinessName { get; set; }
        public int Nit { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool State { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
