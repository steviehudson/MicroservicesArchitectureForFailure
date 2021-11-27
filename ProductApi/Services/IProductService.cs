using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();
    }
}
