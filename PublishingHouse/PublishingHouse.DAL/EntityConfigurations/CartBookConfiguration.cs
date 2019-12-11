using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.EntityConfigurations
{
    class CartBookConfiguration: IEntityTypeConfiguration<CartBook>
    {
        public void Configure(EntityTypeBuilder<CartBook> builder)
        {
            builder.HasKey(bo => bo.Id);
        }
    }
}
