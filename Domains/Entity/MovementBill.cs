using System;
using System.Collections.Generic;

#nullable disable

namespace Billing.Domain.Entity
{
    public partial class MovementBill
    {
        public MovementBill()
        {
            MovementProducts = new HashSet<MovementProduct>();
        }

        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public int IdTransactionType { get; set; }
        public int NumberBill { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual TransactionType IdTransactionTypeNavigation { get; set; }
        public virtual ICollection<MovementProduct> MovementProducts { get; set; }
    }
}
