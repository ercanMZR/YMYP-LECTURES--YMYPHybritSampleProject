using System.Net;
using System.Xml.Linq;
using YMYPHybritSampleProject.Model.Repositories;
using YMYPHybritSampleProject.Model.Repositories.Entities;
using YMYPHybritSampleProject.Model.Services.Dto;

namespace YMYPHybritSampleProject.Model.Services
{
    public class ProductService
    {
        private ProductRepository productRepository;

        private const decimal TaxRate = 1.20m;
        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public ServiceResult<List<ProductDto>> GetProducts()
        {
            var products = productRepository.GetProducts();

            var productsWithTax = new List<ProductDto>();

            foreach (var product in products)
            {
                var productDto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = CalculateTax(product.Price, TaxRate),
                    Stock = product.Stock,
                };

                productsWithTax.Add(productDto);
            }

            return ServiceResult<List<ProductDto>>.Success(productsWithTax, HttpStatusCode.OK);

        }

        public ServiceResult<ProductDto> GetProductById(int productid) 
        {
            var product = productRepository.GetProduct(productid);
            if (product is null)
            {
        // return null; mümkğn oldupunca null dönmicez.

        return ServiceResult<ProductDto>.Failure("Ürün bulunamadı", HttpStatusCode.NotFound);
    }

    var productDto = new ProductDto
    {
                Id = product.Id,
                Name = product.Name,
                Price = CalculateTax(product.Price, TaxRate),
                Stock = product.Stock,
            };

    return ServiceResult<ProductDto>.Success(productDto, HttpStatusCode.OK);

}

public ServiceResult<ProductDto> AddProduct(AddProductRequest addProductDto)
{
            var productName=addProductDto.Name;

            var hasProduct = productRepository.Any(p => p.Name == productName);

            if (hasProduct)
            {
                return ServiceResult<ProductDto>.Failure("Kaydetmeye çalıştığınız ürün ismi veritabanında bulunmamaktadır.", HttpStatusCode.BadRequest);
            }
            var product = new Product
            {
                Id = GenerateId(),
                Name = addProductDto.Name,
                Price = addProductDto.Price,
                Stock = addProductDto.Stock,
                Barcode =GenerateBarcode()


            };

            product=productRepository.AddProduct(product);

            var newProductDto=new ProductDto
            { Id = product.Id, Name = product.Name, Price = CalculateTax(product.Price, TaxRate), Stock = product.Stock, };

            return ServiceResult<ProductDto>.Success(newProductDto, HttpStatusCode.Created);
        }


        public ServiceResult UpdateProduct(UpdateProductRequest updateProductDto)// Geriye bir şey dönmemize gerek yok.Elimizde zaten data var.Buy yüzden void.//

        {
            var anyProduct = productRepository.GetProduct(updateProductDto.Id);

            if(anyProduct != null)
            {
                return ServiceResult.Failure("Güncellenecek ürün bulunamadı",HttpStatusCode.NotFound);
            }

            anyProduct.Name= updateProductDto.Name;
            anyProduct.Price= updateProductDto.Price;

            productRepository.UpdateProduct(anyProduct);

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }


        public ServiceResult DeleteProduct(int productid) 
        {
        var anyProduct = productRepository.GetProduct(productid);

            if ( anyProduct is null)
            {
                return ServiceResult.Failure("Silinecek ürün bulunamadı.",HttpStatusCode.NotFound);
            }

            productRepository.DeleteProduct(productid);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public static decimal CalculateTax(decimal price, decimal taxRate)
        {
            return price * TaxRate;
        }

        private int GenerateId()
        {
            var count = productRepository.GetProductCount();

            return count + 1;
        }

        private string GenerateBarcode()
        {
            return Guid.NewGuid().ToString();
        }

    }   
    
}
