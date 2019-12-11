using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.EntityConfigurations
{
    public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(u => u.Carts)
                .WithOne(l => l.Customer)
                .HasForeignKey(l => l.CustomerId)
                .IsRequired();

            builder.HasMany(u => u.Comments)
                .WithOne(f => f.Customer)
                .HasForeignKey(f => f.CustomerId)
                .IsRequired();

            builder.HasMany(u => u.Orders)
                .WithOne(t => t.Customer)
                .HasForeignKey(t => t.CustomerId)
                .IsRequired();
        }
    }
}
