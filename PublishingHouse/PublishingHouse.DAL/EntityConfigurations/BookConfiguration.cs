using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.EntityConfigurations
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .IsRequired();

            builder.Property(b => b.Language)
                .IsRequired();

            builder.Property(b => b.Year)
                .IsRequired();

            builder.Property(b => b.Format)
                .IsRequired();

            builder.Property(b => b.Cover)
                .IsRequired();

            builder.Property(b => b.PagesAmount)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.Price)
                .IsRequired();

            builder.HasMany(b => b.Comments)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId);

            builder.HasMany(b => b.BookAuthors)
                .WithOne(ba => ba.Book)
                .IsRequired()
                .HasForeignKey(ba => ba.BookId);

            builder.HasMany(b => b.BookCategories)
                .WithOne(bc => bc.Book)
                .IsRequired()
                .HasForeignKey(bc => bc.BookId);

            builder.HasMany(b => b.BookOrders)
                .WithOne(bo => bo.Book)
                .IsRequired()
                .HasForeignKey(bo => bo.BookId);            
        }
    }
}
