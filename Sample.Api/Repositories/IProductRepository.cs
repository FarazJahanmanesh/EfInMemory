using Sample.Api.Models;

namespace Sample.Api.Repositories;

public interface IProductRepository
{
    Task<Product> CreateProduct(ProductDto productDto);
    Task<List<ProductDto>> GetAllProduct();
}