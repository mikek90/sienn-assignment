using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SIENN.DbAccess.DTOs
{
    public partial class Sienn1Context : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

        // Unable to generate entity type for table 'dbo.ProductCategory'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=JUSTYNA-PC;Database=Sienn1;User Id=SiennUser;Password=SiennPass;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Category__A25C5AA79081AE1B")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<Product>(entity =>
            {
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
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Product_Type");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_Product_Unit");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Type__A25C5AA777B9DE99")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
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
