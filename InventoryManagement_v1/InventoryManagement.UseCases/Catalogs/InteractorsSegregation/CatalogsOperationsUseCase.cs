using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Adstractions.UseCasesSegregation.Catalogs;
using InventoryManagement.Entities.Bases;

namespace InventoryManagement.UseCases.Catalogs.InteractorsSegregation
{
    public class CatalogsOperationsUseCase<T> : ICatalogsOperationsUseCase<T> where T : CatalogBaseEntity
    {
        private readonly ICatalogGenericRepository<T> _genericRepository;
        public CatalogsOperationsUseCase(ICatalogGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<int> CreateAsync(T entity, string userAlias)
        {
            entity.CreatedBy = userAlias;
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedBy = userAlias;
            entity.UpdatedDate = DateTime.Now;
            return await _genericRepository.AddAsync(entity);
        }

        public async Task<int> EditAsync(T entity, string userAlias)
        {
            entity.UpdatedBy = userAlias;
            entity.UpdatedDate = DateTime.Now;
            return await _genericRepository.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(T entity)
        {
            return await _genericRepository.RemoveAsync(entity);
        }
        
    }
}
