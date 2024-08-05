using Mapster;
using Microsoft.EntityFrameworkCore;
using Sample.Api.Context;
using Sample.Api.Models;

namespace Sample.Api.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly AppDbContext _dbContext;
    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Product>CreateProduct(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description
        };
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        return await Task.FromResult(product);
    }
    public async Task<List<ProductDto>> GetAllProduct()
    {
        return await _dbContext.Products.AsNoTracking().ProjectToType<ProductDto>().ToListAsync(); 
    }
}
