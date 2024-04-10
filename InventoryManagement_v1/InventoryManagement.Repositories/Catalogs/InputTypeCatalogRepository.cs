using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.Catalogs;
using InventoryManagement.Repositories.Temporal;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace InventoryManagement.Repositories.Catalogs
{
    public class InputTypeCatalogRepository : ISpecificCatalogRepository<InputTypeCatalog>
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<InputTypeCatalog> _entity;
        public InputTypeCatalogRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<InputTypeCatalog>();
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _entity.Where(c => c.InputTypeName!.Trim() == name.Trim()).AnyAsync();
        }

        public async Task<bool> ExistsAsync(int? id, Guid? code)
        {
            return await _entity.Where(c => c.ItemId == id && c.ControlCode == code).AnyAsync();
        }

        public async Task<InputTypeCatalog> GetItemAsync(int id, Guid code, string name)
        {
            var response = await _entity.Where(c => c.ControlCode == code &&
            c.InputTypeName == name && c.ItemId == id).FirstOrDefaultAsync();
            return response!;
        }
    }
}
