using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemApi.DbService.Model;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCatagory> TblCatagories { get; set; }

    public virtual DbSet<TblItem> TblItems { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=InventoryManagementSystem;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCatagory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_Catagory");

            entity.Property(e => e.CatagoryId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CatagoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_Item");

            entity.Property(e => e.ItemCatagory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemPrice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_Order");

            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderItemId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderItemPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OrderTotalPrice).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
