using InventoryManagement.Dtos.Catalogs;
using InventoryManagement.Entities.Bases;

namespace InventoryManagement.Adstractions.UseCasesPorts
{
    public interface ICatalogUseCaseInputPort<T> where T : CatalogBaseEntity
    {
        Task<Task> ShowAllRecordsAsync();
        Task<Task> ShowRecordAsync(int id, RequestCatalogDto request);
        Task<Task> CreateRecordAsync(RequestCatalogDto request);
        Task<Task> EditRecordAsync(RequestByModifyCatalogDto request);
        Task<Task> DeleteRecordAsync(int id, RequestByModifyCatalogDto request);
    }
}
