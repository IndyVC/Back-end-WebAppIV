using ElectricApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricApi.Data {
    public class ElectricContext:IdentityDbContext {

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ElectricContext(DbContextOptions<ElectricContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            //Fluent API Car
            builder.Entity<Car>()
                .HasMany(c => c.Reviews)
                .WithOne()
                .IsRequired();
            builder.Entity<Car>().Property(c => c.Model).IsRequired();
            builder.Entity<Car>().Property(c => c.Brand).IsRequired();
            builder.Entity<Car>().Property(c => c.ChargeTime).IsRequired().HasMaxLength(10);
            builder.Entity<Car>().Property(c => c.MaxSpeed).IsRequired().HasMaxLength(10);
            builder.Entity<Car>().Property(c => c.MaxRange).IsRequired().HasMaxLength(10);
            builder.Entity<Car>().Property(c => c.Price).IsRequired().HasMaxLength(10);
            builder.Entity<Car>().Property(c => c.Image).IsRequired();

            //Fluent API Reviews
            builder.Entity<Review>().Property(r => r.Comment).IsRequired();
            builder.Entity<Review>().Property(r => r.Rating).IsRequired().HasMaxLength(1);

            //Fluent API Customer

            builder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(c => c.Email).IsRequired().HasMaxLength(100);


        }

    }
}
