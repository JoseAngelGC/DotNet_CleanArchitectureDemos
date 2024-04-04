namespace InventoryManagement.Dtos.Catalogs
{
    public class SimpleRequestCatalogDto
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; } = true;
        public string UserAlias { get; set; }
    }
}
