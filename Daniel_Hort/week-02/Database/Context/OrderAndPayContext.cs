using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Database.Context
{
    public class OrderAndPayContext : DbContext
    {
        public OrderAndPayContext() { }
        public OrderAndPayContext(DbContextOptions<OrderAndPayContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=order_and_pay;User Id=sa;Password=Admin0099;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RestaurantEntity>()
                .HasMany(a => a.Menus)
                .WithOne(a => a.Restaurant);
            modelBuilder.Entity<MenuEntity>()
                .HasMany(a => a.Items)
                .WithOne(a => a.Menu);

            modelBuilder.Entity<RestaurantEntity>()
                .HasIndex(a => a.Name).IsUnique();

            modelBuilder.Entity<RestaurantEntity>()
                .Property(a => a.Location).HasConversion<string>(
                    v => $"{v.X} {v.Y}",
                    v =>
                        new PointF(
                            float.Parse(v.Split(' ', StringSplitOptions.None)[0]),
                            float.Parse(v.Split(' ', StringSplitOptions.None)[1]))
                    );
        }

        public DbSet<RestaurantEntity> RestaurantDbSet { get; set; }
        public DbSet<MenuEntity> MenuDbSet { get; set; }
        public DbSet<MenuItemEntity> MenuitemDbSet { get; set; }
    }
}
