using DomainLayer.Models.Auth;
using DomainLayer.Models.orders;
using InfrastructureLayer.ConfigurationEntitys.orders;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
           
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
