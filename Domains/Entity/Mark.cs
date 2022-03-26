using System;
using System.Collections.Generic;

#nullable disable

namespace Billing.Domain.Entity
{
    public partial class Mark
    {
        public Mark()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
