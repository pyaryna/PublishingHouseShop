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

            builder.Property(o => o.Name)
                .IsRequired();

            builder.Property(o => o.Surname)
                .IsRequired();

            builder.Property(o => o.Phone)
                .IsRequired();

            builder.Property(o => o.DateTime)
                .IsRequired();

            builder.Property(o => o.Deliver)
                .IsRequired();

            builder.Property(o => o.DeliverAddress)
                .IsRequired();

            builder.HasMany(o => o.BookOrders)
                .WithOne(bo => bo.Order)
                .IsRequired()
                .HasForeignKey(bo => bo.OrderId);
        }
    }
}
