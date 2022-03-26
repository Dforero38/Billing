using System;
using System.Collections.Generic;

#nullable disable

namespace Billing.Domain.Entity
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            MovementBills = new HashSet<MovementBill>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MovementBill> MovementBills { get; set; }
    }
}
