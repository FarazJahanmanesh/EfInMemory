using Sample.Api.Repositories;

namespace Sample.Api;

public static class IOC
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IProductRepository, ProductRepository>();
    }
}
