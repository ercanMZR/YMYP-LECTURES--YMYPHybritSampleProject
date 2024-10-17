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
        private ProductService ProductService;

        public ProductsController()
        {
            ProductService = new ProductService();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(ProductService.GetProducts());
        }


        [HttpGet("{productId}")]
        public IActionResult GetProduct(int productId)
        {
            return Ok(ProductService.GetProductById(productId));
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
        public IActionResult AddProduct(AddProductDto request) 
        {
            var product=ProductService.AddProduct(request);
            return Created($"api/products/{product.Id}", product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto request)
        {
            ProductService.UpdateProduct(request);

            return NoContent();
        }



        [HttpPatch("stock/{stock}")]
        public IActionResult UpdateProductStock(int stock)
        {
            return NoContent();
        }


        [HttpPatch("price/{price}")] 
        public IActionResult UpdateProductPrice(int price)
        {
            return NoContent();
        }

        [HttpDelete]

        public IActionResult DeleteProduct(int productid)
        {

            ProductService.DeleteProduct(productid);

            return NoContent();
        }
    }
}
