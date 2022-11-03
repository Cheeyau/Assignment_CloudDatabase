using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Review> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ContextString.getString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .ToTable(nameof(Orders))
                .HasKey(order => order.OrderId);
            
            modelBuilder.Entity<Review>()
                .ToTable(nameof(Reviews))
                .HasKey(review => review.ReviewId);
            
            modelBuilder.Entity<User>()
                .ToTable(nameof(Users))
                .HasKey(user => user.UserId);
            
            modelBuilder.Entity<Product>()
                .ToTable(nameof(Product))
                .HasKey(product => product.ProductId);
        }
    }
}
