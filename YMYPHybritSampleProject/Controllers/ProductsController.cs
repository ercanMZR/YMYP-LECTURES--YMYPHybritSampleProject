using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHybritSampleProject.Model.Services;
using YMYPHybritSampleProject.Model.Services.Dto;

namespace YMYPHybritSampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService = new();

        /* public ProductsController()
         {
             ProductService = new ProductService();
         }
        */

        [HttpGet]
        public IActionResult GetProducts() => Ok(_productService.GetProducts());
   
           // return Ok(ProductService.GetProducts());


        [HttpGet("{productId:int}")]
        public IActionResult GetProduct(int productId)
        {
            return Ok(_productService.GetProductById(productId));
        }


       
        //[HttpGet("Size/{pageSize}/Count/{pageCount}")]
        //public IActionResult GetPagedProduct(int pageSize, int pageCount)
        //{
        //    return Ok();
        //}


        [HttpGet("{pageSize}/{pageCount}")]
        public IActionResult GetPagedProduct(int pageSize, int pageCount)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductRequest request) 
        {
            var product=_productService.AddProduct(request);
            return Created($"api/products/{product.Id}", product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductRequest request)
        {
            _productService.UpdateProduct(request);

            return NoContent();
        }



        [HttpPatch("stock/{stock:int}")]
        public IActionResult UpdateProductStock(int stock)
        {
            return NoContent();
        }


        [HttpPatch("price/{price:int}")] 
        public IActionResult UpdateProductPrice(int price)
        {
            return NoContent();
        }

        [HttpDelete("{productId:int}")]

        public IActionResult DeleteProduct(int productid)
        {

            _productService.DeleteProduct(productid);

            return NoContent();
        }
    }
}
