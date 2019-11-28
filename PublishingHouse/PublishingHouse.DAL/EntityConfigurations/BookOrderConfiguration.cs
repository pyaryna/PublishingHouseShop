using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.EntityConfigurations
{
    class BookOrderConfiguration : IEntityTypeConfiguration<BookOrder>
    {
        public void Configure(EntityTypeBuilder<BookOrder> builder)
        {
            builder.HasKey(bo => bo.Id);

            builder.Property(di => di.Amount)
                .IsRequired();
        }
    }
}
