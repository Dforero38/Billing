using Billing.Domain.Entity;
using Billing.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Billing.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BillingContext _context;

        public ProductRepository (BillingContext context)
        {
            _context = context;
        }
        public void InsertProduct (Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public List<Product> GetProducts()
        {
            return _context.Products.Include(include => include.IdMarkNavigation).ToList();
        }

        public Product GetProductByID(int productId)
        {
            return _context.Products.Find(productId);
        }

        public void DeleteProduct(int productID)
        {
            Product product = _context.Products.Find(productID);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public Product ConsultProductByNumber(int idMark)
        {
            return _context.Products.Where(where => where.IdMark.Equals(idMark)).Include(include => include.IdMarkNavigation).FirstOrDefault();

        }

        public void SaveProduct()
        {
            _context.SaveChanges();
        }
    }
}
