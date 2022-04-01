using AutoMapper;
using Billing.Applications.Contracts;
using Billing.Domain.Entity;
using Billing.Domains.Services.Contracts;
using Billing.DTOs;
using System.Collections.Generic;

namespace Billing.Applications
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductDomainService _productDomainService;
        private readonly IMapper _mapper;

        public ProductAppService (IProductDomainService productDomainService, IMapper mapper)
        {
            _productDomainService = productDomainService;
            _mapper = mapper;
        }

        public bool InsertProduct (ProductDTO productDTO)
        {
            try
            {
                Product productMap = _mapper.Map<ProductDTO, Product>(productDTO);
                var result = _productDomainService.InsertProduct(productMap);
                return result;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }
        public bool UpdateProduct(ProductDTO productDTO)
        {
            try
            {
                Product productMap = _mapper.Map<ProductDTO, Product>(productDTO);
                var result = _productDomainService.UpdateProduct(productMap);
                return result;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        public List<ProductDTO> GetProducts()
        {
            try
            {
                var result = _productDomainService.GetProducts();
                List<ProductDTO> product = _mapper.Map<List<Product>, List<ProductDTO>>(result);
                return product;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        public bool DeleteProduct(int productID)
        {
            try
            {
                var result = _productDomainService.DeleteProduct(productID);
                return result;
            }
            catch (System.Exception exception)
            {

                throw exception;
            }
        }

        public List<MarkDTO> GetMarks()
        {
            try
            {
                var result = _productDomainService.GetMark();
                List<MarkDTO> mark = _mapper.Map<List<Mark>, List<MarkDTO>>(result);
                return mark;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }
        public ProductDTO ConsultProductByNumber(int idMark)
        {
            try
            {
                var product = _productDomainService.ConsultProductByNumber(idMark);
                ProductDTO productMap = _mapper.Map<Product, ProductDTO>(product);
                return productMap;
            }
            catch (System.Exception exception)
            {

                throw exception;
            }
        }
    }
}
