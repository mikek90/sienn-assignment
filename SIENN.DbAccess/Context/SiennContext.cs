using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SIENN.BusinessInterfaces;

namespace SIENN.DbAccess.Context
{
    public partial class SiennContext : DbContext
    {
        public SiennContext(DbContextOptions<SiennContext> options)
            : base(options)
        { }

        public virtual DbSet<CategoryDTO> Category { get; set; }
        public virtual DbSet<ProductDTO> Product { get; set; }
        public virtual DbSet<TypeDTO> Type { get; set; }
        public virtual DbSet<UnitDTO> Unit { get; set; }

        // Unable to generate entity type for table 'dbo.ProductCategory'. Please see the warning messages.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryDTO>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Category__A25C5AA79081AE1B")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<ProductDTO>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Product__A25C5AA7DF7E426C")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Type");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Unit");
            });

            modelBuilder.Entity<ProductCategoryDTO>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId });

                entity.HasOne(pc => pc.Product)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(pc => pc.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductCategory_Product");

                entity.HasOne(pc => pc.Category)
                    .WithMany(c => c.ProductCategories)
                    .HasForeignKey(pc => pc.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductCategory_Category");
            });

            modelBuilder.Entity<TypeDTO>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Type__A25C5AA777B9DE99")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<UnitDTO>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Unit__A25C5AA7BC7EA533")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(255);
            });
        }
    }
}
