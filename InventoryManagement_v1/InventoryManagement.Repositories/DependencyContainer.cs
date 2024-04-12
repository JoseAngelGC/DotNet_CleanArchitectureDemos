using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.Catalogs;
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
            services.AddScoped<ISpecificCatalogRepository<CurrencyTypeCatalog>, CurrencyTypeCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<InputTypeCatalog>, InputTypeCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<MeasureUnitCatalog>, MeasureUnitCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<OutputTypeCatalog>, OutputTypeCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<ProductTypeCatalog>, ProductTypeCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<UbicationCatalog>, UbicationCatalogRepository>();

            return services;
        }
    }
}
