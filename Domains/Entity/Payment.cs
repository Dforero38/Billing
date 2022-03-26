using System;
using System.Collections.Generic;

#nullable disable

namespace Billing.Domain.Entity
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public DateTime Date { get; set; }
        public int NumberPayment { get; set; }
        public decimal Value { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
    }
}
