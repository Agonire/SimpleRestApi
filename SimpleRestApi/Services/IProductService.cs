using SimpleRestApi.Models;

namespace SimpleRestApi.Services
{
    public interface IProductService
    {
        Product GetProduct(int productId);
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> GetProcucts();
    }
}