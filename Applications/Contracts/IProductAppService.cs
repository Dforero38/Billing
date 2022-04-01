using Billing.DTOs;
using System.Collections.Generic;

namespace Billing.Applications.Contracts
{
    public interface IProductAppService
    {
        bool InsertProduct(ProductDTO productDTO);
        bool UpdateProduct(ProductDTO productDTO);
        List<ProductDTO> GetProducts();
        bool DeleteProduct(int productID);
        public List<MarkDTO> GetMarks();
        ProductDTO ConsultProductByNumber(int idMark);


    }
}
