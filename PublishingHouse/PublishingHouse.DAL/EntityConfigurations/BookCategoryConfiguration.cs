using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.EntityConfigurations
{
    class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    { 
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(bc => bc.Id);
        }
    }
}
