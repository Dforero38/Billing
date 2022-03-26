using System;
using System.Collections.Generic;

#nullable disable

namespace Billing.Domain.Entity
{
    public partial class Customer
    {
        public Customer()
        {
            MovementBills = new HashSet<MovementBill>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int IdTypeCustomer { get; set; }
        public string BusinessName { get; set; }
        public int Nit { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool State { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual TypeCustomer IdTypeCustomerNavigation { get; set; }
        public virtual ICollection<MovementBill> MovementBills { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
