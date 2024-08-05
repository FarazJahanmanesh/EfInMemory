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
    public async Task<ProductDto>DeleteProduct(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if (product != null)
        {
            _dbContext.Products.ExecuteDeleteAsync();
            _dbContext.Entry(product).State = EntityState.Modified;
            await SaveChangesAsync();
        }
        return await Task.FromResult(product.Adapt<ProductDto>());
    }
    public async Task<ProductDto>UpdateProduct(Product productdto)
    {
        var product = await _dbContext.Products.FindAsync(productdto.Id);
        if (product != null)
        {
            product.Name = productdto.Name;
            product.Description = productdto.Description;

            _dbContext.Entry(product).State = EntityState.Modified;
            await SaveChangesAsync();
        }
        return await Task.FromResult(product.Adapt<ProductDto>());
    }
    public async Task<ProductDto> GetProductById(int id)
    {
        var product = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(d=>d.Id == id);
        return await Task.FromResult(product.Adapt<ProductDto>());
    }
    public async Task<ProductDto> CreateProduct(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description
        };
        _dbContext.Products.Add(product);
        await SaveChangesAsync();

        return await Task.FromResult(product.Adapt<ProductDto>());
    }
    public async Task<List<ProductDto>> GetAllProduct()
    {
        var products =  await _dbContext.Products.AsNoTracking().ProjectToType<ProductDto>().ToListAsync();
        return await Task.FromResult(products);
    }
    private async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
