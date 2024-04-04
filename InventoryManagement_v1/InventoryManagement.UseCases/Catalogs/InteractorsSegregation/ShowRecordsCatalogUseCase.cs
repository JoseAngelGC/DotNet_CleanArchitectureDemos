using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Adstractions.UseCasesSegregation.Catalogs;
using InventoryManagement.Entities.Bases;

namespace InventoryManagement.UseCases.Catalogs.InteractorsSegregation
{
    public class ShowRecordsCatalogUseCase<T> : IShowCatalogUseCase<T> where T : CatalogBaseEntity
    {
        private readonly ICatalogGenericRepository<T> _genericRepository;
        public ShowRecordsCatalogUseCase(ICatalogGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<T>> AllRecordsOrderedByIdDescAsync()
        {
            var getRecords = await _genericRepository.GetAllAsync();

            if (getRecords is not null)
            {
                return getRecords.OrderByDescending(x => x.ItemId).ToList();
            }
            return getRecords!;
        }

        public async Task<T> ItemAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

    }
}
