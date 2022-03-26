using System;
using System.Collections.Generic;

#nullable disable

namespace Billing.Domain.Entity
{
    public partial class MovementProduct
    {
        public int Id { get; set; }
        public int IdMovementBill { get; set; }
        public int IdProduct { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
        public decimal TotalValue { get; set; }

        public virtual MovementBill IdMovementBillNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
