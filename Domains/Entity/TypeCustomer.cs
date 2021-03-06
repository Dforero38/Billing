using System;
using System.Collections.Generic;

#nullable disable

namespace Billing.Domain.Entity
{
    public partial class TypeCustomer
    {
        public TypeCustomer()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
