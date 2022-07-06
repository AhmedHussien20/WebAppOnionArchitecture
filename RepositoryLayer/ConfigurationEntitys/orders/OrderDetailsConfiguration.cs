using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.Models.orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InfrastructureLayer.ConfigurationEntitys.orders
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasOne(x => x.OrderHeader)
                 .WithMany(x => x.OrderDetails)
                 .HasForeignKey(x => x.OrderID)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
