using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Context
{
    public class OrderAndPayContext : DbContext
    {
        public OrderAndPayContext() { }
        public OrderAndPayContext(DbContextOptions<OrderAndPayContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=order_and_pay;User Id=sa;Password=Admin0099;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<RestaurantEntity> RestaurantDbSet { get; set; }
    }
}
