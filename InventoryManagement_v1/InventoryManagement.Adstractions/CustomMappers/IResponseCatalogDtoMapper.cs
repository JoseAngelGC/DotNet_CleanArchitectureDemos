using InventoryManagement.Dtos.Catalogs;
using InventoryManagement.Entities.Bases;

namespace InventoryManagement.Adstractions.CustomMappers
{
    public interface IResponseCatalogDtoMapper
    {
        Task<ResponseCatalogDto> EntityAsync(CatalogBaseEntity baseEntity);
        Task<List<ResponseCatalogDto>> ListAsync(IEnumerable<CatalogBaseEntity> baseEntityList);
    }
}
