using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.EntityConfigurations
{
    class CartConfiguration: IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasMany(b => b.CartBooks)
                .WithOne(bo => bo.Cart)
                .IsRequired()
                .HasForeignKey(bo => bo.CartId);
        }
    }
}
