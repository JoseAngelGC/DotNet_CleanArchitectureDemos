using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Repositories.Catalogs;
using InventoryManagement.Repositories.Generics;
using InventoryManagement.Repositories.Temporal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            //DbContext service register
            var assembly = typeof(InventoryManagementContext).Assembly.FullName;
            services.AddDbContext<InventoryManagementContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionDev"),
                opt => opt.MigrationsAssembly(assembly)), ServiceLifetime.Transient
                );

            //Repositories register
            services.AddScoped(typeof(ICatalogGenericRepository<>), typeof(CatalogGenericRepository<>));
            services.AddScoped<ICurrencyTypeCatalogRepository, CurrencyTypeCatalogRepository>();

            return services;
        }
    }
}
