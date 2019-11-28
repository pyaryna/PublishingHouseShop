using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.EntityConfigurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.DateTime)
                .IsRequired();

            builder.Property(b => b.DeliverAddress)
                .IsRequired();

            builder.HasMany(b => b.BookOrders)
                .WithOne(bo => bo.Order)
                .IsRequired()
                .HasForeignKey(bo => bo.OrderId);
        }
    }
}
