using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class FridgeDataBaseContext : DbContext
{
    public FridgeDataBaseContext()
    {
    }

    public FridgeDataBaseContext(DbContextOptions<FridgeDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fridge> Fridges { get; set; }

    public virtual DbSet<FridgeModel> FridgeModels { get; set; }

    public virtual DbSet<FridgeProduct> FridgeProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=f4632l2384u2475\\sqlexpress;Database=FridgeDataBase;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fridge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Fridge_Id");

            entity.ToTable("Fridge");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OwnerName)
                .HasMaxLength(255)
                .HasColumnName("owner_name");

            entity.HasOne(d => d.Model).WithMany(p => p.Fridges)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("FK_Fridge_ModelId");
        });

        modelBuilder.Entity<FridgeModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FridgeModel_Id");

            entity.ToTable("FridgeModel");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<FridgeProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_fridge_Products_Id");

            entity.ToTable("fridge_products");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.FridgeId).HasColumnName("Fridge_Id");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Fridge).WithMany(p => p.FridgeProducts)
                .HasForeignKey(d => d.FridgeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fridge_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.FridgeProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Product_Id");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DefaultQuantity).HasColumnName("default_quantity");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
