using FluentValidation;
using InventoryManagement.Adstractions.Helpers;
using InventoryManagement.Adstractions.UseCasesPorts;
using InventoryManagement.Adstractions.UseCasesSegregation.Catalogs;
using InventoryManagement.Entities.Catalogs;
using InventoryManagement.UseCases.Catalogs;
using InventoryManagement.UseCases.Catalogs.InteractorsSegregation;
using InventoryManagement.UseCases.Catalogs.Validators;
using InventoryManagement.UseCases.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            //Register validators
            services.AddValidatorsFromAssemblyContaining<RequestByModifyCatalogDtoValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<RequestCatalogDtoValidator>(ServiceLifetime.Transient);

            //Register use cases (InputPort-Interactor)
            services.AddScoped<ICatalogUseCaseInputPort<CurrencyTypeCatalog>, CurrencyCatalogCrudInteractor>();
            services.AddScoped<ICatalogUseCaseInputPort<InputTypeCatalog>, InputCatalogCrudInteractor>();

            //Register use cases (Interface Segregation-Interactor)
            services.AddScoped(typeof(ICatalogQueryOperationsUseCase<CurrencyTypeCatalog>), typeof(CatalogQueryOperationsUseCase<CurrencyTypeCatalog>));
            services.AddScoped(typeof(ICatalogCommandOperationsUseCase<CurrencyTypeCatalog>), typeof(CatalogCommandOperationsUseCase<CurrencyTypeCatalog>));
            services.AddScoped(typeof(ICatalogQueryOperationsUseCase<InputTypeCatalog>), typeof(CatalogQueryOperationsUseCase<InputTypeCatalog>));
            services.AddScoped(typeof(ICatalogCommandOperationsUseCase<InputTypeCatalog>), typeof(CatalogCommandOperationsUseCase<InputTypeCatalog>));

            //Register Helpers
            services.AddScoped<IResponseResultHelpers, ResponseResultHelpers>();

            return services;
        }
    }
}
