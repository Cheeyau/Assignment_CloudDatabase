using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class OrderContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ContextString.getString());
        }
    }
}
