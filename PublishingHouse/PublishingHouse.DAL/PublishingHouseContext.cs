using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.DAL.Entities;
using PublishingHouse.DAL.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL
{
    public class PublishingHouseContext: IdentityDbContext
    {   
        public PublishingHouseContext(DbContextOptions<PublishingHouseContext> options): base(options){}

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SetConfigurations();
            builder.Seed();
        }
    }
}
