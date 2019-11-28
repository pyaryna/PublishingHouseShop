using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.EntityConfigurations
{
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Text)
                .IsRequired();

            builder.Property(c => c.DateTime)
                .IsRequired();

            builder.HasOne(c => c.Book)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.BookId);
        }
    }
}
