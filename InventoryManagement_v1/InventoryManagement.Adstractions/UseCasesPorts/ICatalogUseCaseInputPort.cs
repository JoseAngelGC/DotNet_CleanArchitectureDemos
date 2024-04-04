using InventoryManagement.Dtos.Catalogs;

namespace InventoryManagement.Adstractions.UseCasesPorts
{
    public interface ICatalogUseCaseInputPort
    {
        Task<Task> ShowAllRecordsAsync();
        Task<Task> ShowRecordAsync(int id, RequestCatalogDto request);
        Task<Task> CreateRecordAsync(RequestCatalogDto request);
        Task<Task> EditRecordAsync(RequestCatalogDto request);
        Task<Task> DeleteRecordAsync(int id, RequestCatalogDto request);
    }
}
