using System;
using System.Collections.Generic;

#nullable disable

namespace Billing.Domain.Entity
{
    public partial class Product
    {
        public Product()
        {
            MovementProducts = new HashSet<MovementProduct>();
            Residues = new HashSet<Residue>();
        }

        public int Id { get; set; }
        public int IdMark { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual Mark IdMarkNavigation { get; set; }
        public virtual ICollection<MovementProduct> MovementProducts { get; set; }
        public virtual ICollection<Residue> Residues { get; set; }
    }
}
