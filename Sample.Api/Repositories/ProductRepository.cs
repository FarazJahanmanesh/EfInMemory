using Sample.Api.Context;

namespace Sample.Api.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly AppDbContext _dbContext;
    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
