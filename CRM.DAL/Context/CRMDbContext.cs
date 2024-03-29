﻿using CRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DAL.Context
{
    public class CRMDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<WorkingRate> WorkingRates { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrdersDetails { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<SupplyDetails> SuppliesDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Customer>()
                .Property(c => c.CashbackBalance)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Login)
                .IsRequired();

                entity.Property(e => e.Password)
                .IsRequired();

                entity.Property(e => e.DateOfBirth)
                .HasColumnType("date");

                entity.Property(e => e.HireDate)
                .HasColumnType("date");

                entity.Property(e => e.Extension)
                .HasColumnType("date");
            });

            modelBuilder.Entity<Order>(entity => 
            {
                entity
                .Property(e => e.ShippingCost)
                .HasColumnType("decimal(18,2)");

                entity
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasOne(o => o.Order)
                .WithMany(d => d.OrderDetails)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.ClientCascade);

                entity.HasOne(o => o.Product)
                .WithMany(d => d.OrderDetails)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Discount)
                .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Supply>()
                .Property(e => e.SupplyCost)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SupplyDetails>(entity =>
            {
                entity.HasOne(s => s.Supply)
                .WithMany(d => d.SupplyDetails)
                .HasForeignKey(s => s.SupplyId)
                .OnDelete(DeleteBehavior.ClientCascade);

                entity.HasOne(s => s.Product)
                .WithMany(d => d.SupplyDetails)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18,2)");
            });
        }

        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options) { }
    }
}
