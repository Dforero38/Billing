using System;
using System.Collections.Generic;

#nullable disable

namespace Billing.Domain.Entity
{
    public partial class Residue
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public decimal Stok { get; set; }

        public virtual Product IdProductNavigation { get; set; }
    }
}
