using SimpleRestApi.Models;

namespace SimpleRestApi.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> _productPersistenceMock = new()
        {
            new Product(1, "Week's offer", 5),
            new Product(2, "Student's choice", 3),
            new Product(3, "Big and juicy", 7),
            new Product(4, "Friend party", 15),
        };
        public Product? GetProduct(int id)
        {
            return GetProcucts().FirstOrDefault(p => p.Id == id);
        }
        public List<Product> GetProcucts()
        {
            return _productPersistenceMock;
        }
        public void DeleteProduct(Product product)
        {
            if (_productPersistenceMock.Contains(product))
                _productPersistenceMock.Remove(product);
        }
        public void AddProduct(Product product)
        {
            if (_productPersistenceMock.Any(p => p.Id == product.Id))
                throw new Exception("Such product entity already exists");

            _productPersistenceMock.Add(product);
        }
    }
}
