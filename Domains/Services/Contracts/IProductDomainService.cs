using Billing.Domain.Entity;
using System.Collections.Generic;

namespace Billing.Domains.Services.Contracts
{
    public interface IProductDomainService
    {
        bool InsertProduct(Product product);
        bool UpdateProduct(Product product);
        List<Product> GetProducts();
        bool DeleteProduct(int productID);
        Product ConsultProductByNumber(int idMark);
        List<Mark> GetMark();
    }
}
