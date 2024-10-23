using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using YMYPHybritSampleProject.Model.Services;
using YMYPHybritSampleProject.Model.Services.Dto;

namespace YMYPHybritSampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomControllerBase
    {
        private readonly ProductService _productService = new();

        /* public ProductsController()
         {
             ProductService = new ProductService();
         }
        */

        [HttpGet]
       public IActionResult GetProducts()
        {
            var result = _productService.GetProducts();

            return new ObjectResult(result)
            {
                StatusCode = (int)result.Status
            };
        }
           // return Ok(ProductService.GetProducts());


        [HttpGet("{productId:int}")]
        public IActionResult GetProduct(int productId)
        {
           var result =_productService.GetProductById(productId);

            if(result.Status== HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)result.Status
                };
            }

            return new ObjectResult(result)
            {
                StatusCode= (int)result.Status
            };
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
            var result=_productService.AddProduct(request);
            return new ObjectResult(result)
            {
                StatusCode = (int)result.Status
            };
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductRequest request)
        {
            var result =_productService.UpdateProduct(request);

            return new ObjectResult(result)
            {
                StatusCode = (int)result.Status
            };
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

            var result=_productService.DeleteProduct(productid);

            if (result.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)result.Status
                };
            }


            return new ObjectResult(result)
            {
                StatusCode = (int)result.Status
            };
        }

    }
}
