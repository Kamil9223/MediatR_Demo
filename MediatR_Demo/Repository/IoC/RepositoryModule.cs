using Data;
using Microsoft.Extensions.DependencyInjection;

namespace Repository.IoC
{
    public static class RepositoryModule
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            return services;
        }
    }
}
