using Billing.Applications.Contracts;
using Billing.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Billing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        public ProductController (IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpPost]
        [Route(nameof(ProductController.InsertProduct))]
        public bool InsertProduct(ProductDTO productDTO)
        {
            return _productAppService.InsertProduct(productDTO);
        }

        [HttpPut]
        [Route(nameof(ProductController.UpdateProduct))]
        public bool UpdateProduct(ProductDTO productDTO)
        {
            return _productAppService.UpdateProduct(productDTO);
        }

        [HttpGet]
        [Route(nameof(ProductController.GetProduct))]
        public List<ProductDTO> GetProduct()
        {
            return _productAppService.GetProducts();
        }

        [HttpDelete]
        [Route(nameof(ProductController.DeleteProduct))]
        public bool DeleteProduct(int id)
        {
            return _productAppService.DeleteProduct(id);
        }

        [HttpGet]
        [Route(nameof(ProductController.GetMark))]
        public List<MarkDTO> GetMark()
        {
            return _productAppService.GetMarks();
        }

        [HttpGet]
        [Route(nameof(ProductController.ConsultProductByNumber))]
        public ProductDTO ConsultProductByNumber(int idMark)
        {
            return _productAppService.ConsultProductByNumber(idMark);
        }

    }
}
