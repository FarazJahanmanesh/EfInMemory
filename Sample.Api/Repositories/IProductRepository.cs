using Sample.Api.Models;

namespace Sample.Api.Repositories;

public interface IProductRepository
{
    Task<ProductDto> CreateProduct(ProductDto productDto);
    Task<List<ProductDto>> GetAllProduct();
}