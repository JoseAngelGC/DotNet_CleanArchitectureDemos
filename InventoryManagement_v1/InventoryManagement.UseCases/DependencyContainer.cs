using FluentValidation;
using InventoryManagement.Adstractions.CustomMappers;
using InventoryManagement.Adstractions.Helpers;
using InventoryManagement.Adstractions.UseCasesPorts;
using InventoryManagement.Adstractions.UseCasesSegregation.Catalogs;
using InventoryManagement.Entities.Catalogs;
using InventoryManagement.UseCases.Catalogs;
using InventoryManagement.UseCases.Catalogs.InteractorsSegregation;
using InventoryManagement.UseCases.Catalogs.Validators;
using InventoryManagement.UseCases.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InventoryManagement.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            //Register validators
            services.AddValidatorsFromAssemblyContaining<CatalogRequestDtoValidator>(ServiceLifetime.Transient);

            //Register use cases (InputPort-Interactor)
            services.AddScoped<ICatalogUseCaseInputPort, CurrencyCatalogCrudInteractor>();

            //Register use cases (Interface Segregation-Interactor)
            services.AddScoped(typeof(IShowCatalogUseCase<CurrencyTypeCatalog>), typeof(ShowRecordsCatalogUseCase<CurrencyTypeCatalog>));
            services.AddScoped(typeof(ICatalogsOperationsUseCase<CurrencyTypeCatalog>), typeof(CatalogsOperationsUseCase<CurrencyTypeCatalog>));

            //Register Helpers
            services.AddScoped<IResponseResultHelpers, ResponseResultHelpers>();

            return services;
        }
    }
}
