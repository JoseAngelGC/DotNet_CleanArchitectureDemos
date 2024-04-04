using InventoryManagement.Entities.Bases;

namespace InventoryManagement.Adstractions.UseCasesSegregation.Catalogs
{
    public interface ICatalogsOperationsUseCase<T> where T : CatalogBaseEntity
    {
        Task<int> CreateAsync(T entity, string userAlias);
        Task<int> EditAsync(T entity, string userAlias);
        Task<int> DeleteAsync(T entity);
    }
}
