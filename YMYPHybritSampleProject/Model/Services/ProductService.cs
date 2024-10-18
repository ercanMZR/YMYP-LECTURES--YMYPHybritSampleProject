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

        public List<ProductDto> GetProducts()
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

            return productsWithTax;

        }

        public ProductDto GetProductById(int productid) 
        {
            var product = productRepository.GetProduct(productid);
            if (product is null)
            {
                // return null; mümkğn oldupunca null dönmicez.

                throw new Exception("Product  not found");
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = CalculateTax(product.Price, TaxRate),
                Stock = product.Stock,
            };

        }

        public ProductDto AddProduct(AddProductRequest addProductDto)
        {
            var product = new Product
            {
                Id = GenerateId(),
                Name = addProductDto.Name,
                Price = addProductDto.Price,
                Stock = addProductDto.Stock,
                Barcode =GenerateBarcode()


            };

            product=productRepository.AddProduct(product);

            return new ProductDto { Id = product.Id, Name = product.Name, Price = CalculateTax(product.Price, TaxRate), Stock = product.Stock, };
        }


        public void UpdateProduct(UpdateProductRequest updateProductDto)// Geriye bir şey dönmemize gerek yok.Elimizde zaten data var.Buy yüzden void.//

        {
            var anyProduct = productRepository.GetProduct(updateProductDto.Id);

            if(anyProduct != null)
            {
                throw new Exception("Product not found");
            }

            anyProduct.Name= updateProductDto.Name;
            anyProduct.Price= updateProductDto.Price;

            productRepository.UpdateProduct(anyProduct);

        }


        public void DeleteProduct(int productid) 
        {
        var anyProduct = productRepository.GetProduct(productid);

            if ( anyProduct is null)
            {
                throw new Exception("Product not found");
            }

            productRepository.DeleteProduct(productid);
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
