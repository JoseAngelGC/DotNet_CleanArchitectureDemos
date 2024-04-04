﻿using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.Catalogs;
using InventoryManagement.Repositories.Generics;
using InventoryManagement.Repositories.Temporal;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Catalogs
{
    public class CurrencyTypeCatalogRepository : ICurrencyTypeCatalogRepository
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<CurrencyTypeCatalog> _entity;

        public CurrencyTypeCatalogRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<CurrencyTypeCatalog>();
        }

        public async Task<CurrencyTypeCatalog> GetItemAsync(int id, Guid controlCode, string name)
        {
            var response = await _entity.Where(c => c.ControlCode == controlCode &&
            c.CurrencyTypeName == name && c.ItemId == id).FirstOrDefaultAsync();
            return response!;
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _entity.Where(c => c.CurrencyTypeName!.Trim() == name.Trim()).AnyAsync();
        }

        public async Task<bool> ExistsAsync(int? id, Guid? controlCode)
        {
            return await _entity.Where(c => c.ItemId == id && c.ControlCode == controlCode).AnyAsync();
        }
    }
}