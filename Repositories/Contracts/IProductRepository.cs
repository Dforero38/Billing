using Billing.Domain.Entity;
using System.Collections.Generic;

namespace Billing.Repositories.Contracts
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void InsertProduct(Product product);
        Product GetProductByID(int productId);
        void DeleteProduct(int productID);
        void UpdateProduct(Product product);
        Product ConsultProductByNumber(int idMark);
        void SaveProduct();
    }
}
