using Billing.Domain.Entity;
using Billing.Domains.Services.Contracts;
using Billing.Repositories.Contracts;
using System.Collections.Generic;

namespace Billing.Domains.Services
{
    public class ProductDomainService : IProductDomainService 
    {
        private readonly IProductRepository _productRepository;
        private readonly IMarkRepository _markRepository;
        

        public ProductDomainService (IProductRepository productRepository, IMarkRepository markRepository)
        {
            _productRepository = productRepository;
            _markRepository = markRepository;

        }
        public bool InsertProduct(Product product)
        {
            try
            {
                _productRepository.InsertProduct(product);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateProduct (Product product)
        {
            try
            {
                _productRepository.UpdateProduct(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                return _productRepository.GetProducts();
            }
            catch
            {
                return new List<Product>();
            }
        }

        public bool DeleteProduct(int productID)
        {
            try
            {
                _productRepository.DeleteProduct(productID);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public List<Mark> GetMark()
        {
            try
            {
                return _markRepository.GetMarks();
            }
            catch
            {
                return new List<Mark>();
            }
        }
        public Product ConsultProductByNumber(int idMark)
        {
            try
            {
                return _productRepository.ConsultProductByNumber(idMark);
            }
            catch
            {

                return new Product();
            }
        }
    }
}
