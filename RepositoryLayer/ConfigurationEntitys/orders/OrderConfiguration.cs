using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.Models.orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InfrastructureLayer.ConfigurationEntitys.orders
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_orderid");
            builder.ToTable("OrderHeader", "dbo");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.CustomerName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PhoneNo).IsRequired().HasMaxLength(50);
            
            

        }
    }
}
