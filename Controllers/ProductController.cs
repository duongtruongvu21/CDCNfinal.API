using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDCNfinal.API.Data.DTOs;
using CDCNfinal.API.Services.ProductServices.cs;
using Microsoft.AspNetCore.Mvc;

namespace CDCNfinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductDTO>> Get()
        {
            var productDTOs = _productService.GetProducts();
            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDetailDTO> Get(int id)
        {
            var productDetailDTO = _productService.GetProductById(id);
            return Ok(productDetailDTO);
        }

        [HttpPost]
        public ActionResult Post(ProductAddDTO productAddDTO)
        {
            _productService.CreateProduct(productAddDTO);
            if(_productService.SaveChanges()) return NoContent();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Put(ProductDetailDTO product)
        {
            if(_productService.GetProductById(product.Id) == null){
                return NotFound("Product is invalid");
            }
            _productService.UpdateProduct(product);
            if(_productService.SaveChanges()) return NoContent();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(_productService.GetProductById(id) == null){
                return NotFound("Product is invalid");
            }
            _productService.DeleteProduct(id);
            if(_productService.SaveChanges()) return NoContent();
            return BadRequest();
        }
    }
}