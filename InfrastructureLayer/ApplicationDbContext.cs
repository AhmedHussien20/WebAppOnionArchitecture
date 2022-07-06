using DomainLayer.ConfigurationEntitys.orders;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace RepositoryLayer
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
