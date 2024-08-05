using Sample.Api.Models;

namespace Sample.Api.Repositories;

public interface IProductRepository
{
    Task<ProductDto> CreateProduct(ProductDto productDto);
    Task<List<ProductDto>> GetAllProduct();
    Task<ProductDto> DeleteProduct(int id);
    Task<ProductDto> UpdateProduct(Product productdto);
    Task<ProductDto> GetProductById(int id);
}