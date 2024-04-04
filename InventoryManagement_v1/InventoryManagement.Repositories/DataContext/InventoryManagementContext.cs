using InventoryManagement.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Temporal
{
    public partial class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext()
        {
        }

        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CurrencyTypeCatalog> CurrencyTypeCatalogs { get; set; } = null!;
        public virtual DbSet<InputTypeCatalog> InputTypeCatalogs { get; set; } = null!;
        public virtual DbSet<MeasureUnitCatalog> MeasureUnitCatalogs { get; set; } = null!;
        public virtual DbSet<OutputTypeCatalog> OutputTypeCatalogs { get; set; } = null!;
        public virtual DbSet<ProductTypeCatalog> ProductTypeCatalogs { get; set; } = null!;
        public virtual DbSet<UbicationCatalog> UbicationCatalogs { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyTypeCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_CurrencyTypeControlCode");

                entity.ToTable("CurrencyTypeCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("currencyTypeName");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InputTypeCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_InputTypeControlCode");

                entity.ToTable("InputTypeCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InputTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MeasureUnitCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_MeasureUnitControlCode");

                entity.ToTable("MeasureUnitCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.MeasureUnitName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("measureUnitName");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OutputTypeCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_OutputTypeControlCode");

                entity.ToTable("OutputTypeCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.OutputTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductTypeCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_ProductTypeControlCode");

                entity.ToTable("ProductTypeCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.ProductTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productTypeName");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UbicationCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_UbicationControlCode");

                entity.ToTable("UbicationCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UbicationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ubicationName");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
