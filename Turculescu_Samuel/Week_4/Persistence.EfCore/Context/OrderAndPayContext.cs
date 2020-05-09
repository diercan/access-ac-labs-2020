using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Persistence.EfCore;

namespace Persistence.EfCore.Context
{
    public partial class OrderAndPayContext : DbContext
    {
        public OrderAndPayContext()
        {
        }

        public OrderAndPayContext(DbContextOptions<OrderAndPayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

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
                entity.Property(r => r.Name).HasMaxLength(500);

                entity.Property(r => r.Address).HasMaxLength(500);                
            });

            // CLIENT
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(c => c.FirstName).HasMaxLength(50);

                entity.Property(c => c.LastName).HasMaxLength(50);

                entity.Property(c => c.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(c => c.Email).HasMaxLength(800);

                entity.Property(c => c.CardNumber)
                    .HasMaxLength(16)
                    .IsFixedLength();

                entity.Property(c => c.Username).HasMaxLength(50);

                entity.Property(c => c.Password).HasMaxLength(128);             
            });

            // EMPLOYEE
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email).HasMaxLength(800);

                entity.Property(e => e.Job).HasMaxLength(100);                    

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(128);

                entity.Property(e => e.RestaurantId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

