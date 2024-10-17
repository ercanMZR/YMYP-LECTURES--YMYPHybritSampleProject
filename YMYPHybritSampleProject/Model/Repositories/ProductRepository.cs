using YMYPHybritSampleProject.Model.Repositories.Entities;

namespace YMYPHybritSampleProject.Model.Repositories
{
    public class ProductRepository
    {
        public static List<Product> Products {  get; set; }


        static ProductRepository()
        {
            Products =
            [
                new Product { Id = 1, Name = "Product 1", Price = 100, Stock = 10 },
                new Product { Id = 2, Name = "Product 2", Price = 200, Stock = 20 },
                new Product { Id = 3, Name = "Product 3", Price = 300, Stock = 30 },
                new Product { Id = 4, Name = "Product 4", Price = 400, Stock = 40 },
                new Product { Id = 5, Name = "Product 5", Price = 500, Stock = 50 }
            ];
        }

        public List<Product>GetProducts() => Products;
        public Product? GetProduct(int id)
        {
            return Products.FirstOrDefault(p=> p.Id == id);
        }

        public Product AddProduct(Product product)
        {
            Products.Add(product);
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            var existingProduct=Products.First(p=>p.Id == product.Id);

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            return existingProduct;
        }

        public int GetProductCount()
        {
        
           return Products.Count;
        }

        public void DeleteProduct(int id)
        {
            var product = Products.First(p => p.Id == id);
            Products.Remove(product);
        }

    }
}
