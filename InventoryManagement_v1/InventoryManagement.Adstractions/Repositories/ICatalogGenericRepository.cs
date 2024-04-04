using InventoryManagement.Entities.Bases;

namespace InventoryManagement.Adstractions.Repositories
{
    public interface ICatalogGenericRepository<T> where T : CatalogBaseEntity 
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> RemoveAsync(T entity);
    }
}
