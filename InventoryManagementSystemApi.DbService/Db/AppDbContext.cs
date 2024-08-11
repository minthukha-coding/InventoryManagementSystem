using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemApi.DbService.Db;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblItem> TblItems { get; set; }

    public virtual DbSet<TblLogin> TblLogins { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblOrderInvoice> TblOrderInvoices { get; set; }

    public virtual DbSet<TblOrderItem> TblOrderItems { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=InventoryManagementSystem;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("tbl_category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoryId");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoryName");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("createdDateTime");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdUserId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("updatedDateTime");
            entity.Property(e => e.UpdatedUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updatedUserId");
        });

        modelBuilder.Entity<TblItem>(entity =>
        {
            entity.HasKey(e => e.ItemName);

            entity.ToTable("tbl_item");

            entity.Property(e => e.ItemName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("createdDateTime");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdUserId");
            entity.Property(e => e.ItemAmount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("updatedDateTime");
            entity.Property(e => e.UpdatedUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updatedUserId");
        });

        modelBuilder.Entity<TblLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tbl_login_1");

            entity.ToTable("tbl_login");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessToken)
                .IsUnicode(false)
                .HasColumnName("accessToken");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.LoginDate).HasColumnName("loginDate");
            entity.Property(e => e.LogoutDate).HasColumnName("logoutDate");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userId");
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_Tbl_Order");

            entity.ToTable("tbl_order");

            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("orderId");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.CustomerUserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("customerUserId");
            entity.Property(e => e.IsDeliveried).HasColumnName("isDeliveried");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.OrderItemAmount)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("orderItemAmount");
            entity.Property(e => e.OrderItemId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("orderItemId");
            entity.Property(e => e.OrderItemPrice)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("orderItemPrice");
            entity.Property(e => e.OrderItemTotalPrice)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("orderItemTotalPrice");
        });

        modelBuilder.Entity<TblOrderInvoice>(entity =>
        {
            entity.HasKey(e => e.OrderInvoiceId);

            entity.ToTable("tbl_orderInvoice");

            entity.Property(e => e.OrderInvoiceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("orderInvoiceId");
            entity.Property(e => e.InvoiceDate)
                .HasColumnType("datetime")
                .HasColumnName("invoiceDate");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("orderId");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalAmount");
        });

        modelBuilder.Entity<TblOrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId);

            entity.ToTable("tbl_orderItem");

            entity.Property(e => e.OrderItemId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("orderItemId");
            entity.Property(e => e.ItemId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("itemId");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("orderId");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quantity");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UsereId).HasName("PK_Tbl_User");

            entity.ToTable("tbl_user");

            entity.Property(e => e.UsereId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usereId");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("createdDateTime");
            entity.Property(e => e.HashPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hashPassword");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedDateTime)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("updatedDateTime");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
