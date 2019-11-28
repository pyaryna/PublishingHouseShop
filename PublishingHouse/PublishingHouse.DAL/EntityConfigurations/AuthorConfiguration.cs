using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.EntityConfigurations
{
    class AuthorConfiguration: IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired();

            builder.HasMany(a => a.BookAuthors)
                .WithOne(ba => ba.Author)
                .IsRequired()
                .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
