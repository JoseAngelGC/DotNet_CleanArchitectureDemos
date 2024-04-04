using InventoryManagement.Entities.Catalogs;

namespace InventoryManagement.Adstractions.Repositories
{
    public interface ICurrencyTypeCatalogRepository
    {
        Task<CurrencyTypeCatalog> GetItemAsync(int id, Guid coltrolCode, string name);
        Task<bool> ExistsAsync(string name);
        Task<bool> ExistsAsync(int? id, Guid? controlCode);
    }
}
