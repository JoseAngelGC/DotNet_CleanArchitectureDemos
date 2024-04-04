using InventoryManagement.Entities.Bases;

namespace InventoryManagement.Adstractions.UseCasesSegregation.Catalogs
{
    public interface IShowCatalogUseCase<T> where T : CatalogBaseEntity
    {
        Task<IEnumerable<T>> AllRecordsOrderedByIdDescAsync();
        Task<T> ItemAsync(int id);
    }
}
