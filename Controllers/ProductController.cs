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
        public async Task<ActionResult<string>> Post([FromForm]  ProductAddDTO productAddDTO)
        {
            try{
                if(await _productService.CreateProduct(productAddDTO)) return NoContent();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(int id,[FromForm] ProductAddDTO product)
        {

            try{
                if(await _productService.UpdateProduct(id,product)){
                    var result = _productService.GetProductById(id);
                    return Ok(result);
                }
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
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