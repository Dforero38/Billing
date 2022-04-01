using Billing.Domain.Entity;
using Billing.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Billing.Repositories
{
    public class MovementProductRepository : IMovementProductRepository
    {
        private readonly BillingContext _context;

        public MovementProductRepository(BillingContext context)
        {
            _context = context;
        }
        public List<MovementProduct> GetMovementProducts()
        {
            return _context.MovementProducts.Include(include => include.IdProduct).ToList();
        }
        public MovementProduct GetMovementProductByID(int movementProductId)
        {
            return _context.MovementProducts.Find(movementProductId);
        }
        public void InsertMovementProduct (MovementProduct movementProduct)
        {
            _context.MovementProducts.Add(movementProduct);
            _context.SaveChanges();
        }
        public void DeleteMovementProduct(int movementProductID)
        {
            MovementProduct movementProduct = _context.MovementProducts.Find(movementProductID);
            _context.MovementProducts.Remove(movementProduct);
            _context.SaveChanges();
        }

        public void UpdateMovementProduct(MovementProduct movementProducts)
        {
            _context.Entry(movementProducts).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void SaveMovementProduct()
        {
            _context.SaveChanges();
        }

    }
    
}
