using Billing.Domain.Entity;
using Billing.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Billing.Repositories
{
    public class ResidueRepository : IResidueRepository
    {
        private readonly BillingContext _context;

        public ResidueRepository(BillingContext context)
        {
            _context = context;
        }
        public void InsertResidue(int product, int quantity)
        {
            var findIdProduct = _context.Residues.FirstOrDefault(first => first.IdProduct.Equals(product));
            if (findIdProduct == null)
            {
                Residue residue = new Residue()
                {
                    IdProduct = product,
                    Stok = quantity
                };
                _context.Residues.Add(residue);
            }else
            {
                findIdProduct.Stok = findIdProduct.Stok + quantity;
                _context.Entry(findIdProduct).State = EntityState.Modified;
            }           
            _context.SaveChanges();
        }      
    }
}
