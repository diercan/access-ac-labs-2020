using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt.TypeClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Persistence.EfCore;

namespace Persistence.EfCore.Context
{
    public partial class OrderAndPayContext : DbContext
    {
        public List<Restaurant>restaurants;

        public OrderAndPayContext()
        {
            var Ord = new OrderAndPayContext();
            restaurants = Ord.Restaurant
                            .FromSqlRaw("SELECT * FROM dbo.Restaurant")
                            .ToList();
        }

        public OrderAndPayContext(DbContextOptions<OrderAndPayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost\\sqlexpress;Initial Catalog=OrderAndPay;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // RESTAURANT
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(r => r.Name)
                .HasMaxLength(500);

                entity.Property(r => r.Address)
                .HasMaxLength(500);                
            });

            // CLIENT
            modelBuilder.Entity<Client>(entity =>
            {                          
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(800);                

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CardNumber)
                   .HasMaxLength(16)
                   .IsFixedLength();

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(128);
            });

            // EMPLOYEE
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(800);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength();                

                entity.Property(e => e.Job)
                    .HasMaxLength(100);                    

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(128);

                entity.Property(e => e.RestaurantId);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK_Employee_Restaurant");
            });

            // MENU
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK_Menu_Restaurant");
            });

            // MENU ITEM
            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.Allergens);

                entity.Property(e => e.Ingredients);

                entity.Property(e => e.Name)
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .HasColumnType("money");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_MenuItem_Menu");
            });

            // ORDER ITEM
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Name)
                .HasMaxLength(50);

                entity.Property(e => e.SpecialRequests);
  
                entity.Property(e => e.Price)
                    .HasColumnType("money");

                entity.HasOne(d => d.MenuItem)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.MenuItemId)
                    .HasConstraintName("FK_OrderItem_MenuItem");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderItem_Order");
            });

            // ORDER
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DateTimePlaced)
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(50);                

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PlacedOrders)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Order_Client");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK_Order_Restaurant");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

