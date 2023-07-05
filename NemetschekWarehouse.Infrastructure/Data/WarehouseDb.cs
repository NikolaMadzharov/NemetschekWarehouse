using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NemetschekWarehouse.Infrastructure.Data.Entities;
using NemetschekWarehouse.Infrastructure.Data.Entities.User;
using Type = NemetschekWarehouse.Infrastructure.Data.Entities.Type;

namespace NemetschekWarehouse.Infrastructure.data
{
    public class WarehouseDb : IdentityDbContext<Guest>
    {
        public WarehouseDb(DbContextOptions<WarehouseDb> options)
            : base(options)
        {

        }


        public DbSet<Product> Products { get; set; }

        public DbSet<Type> Types { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasOne(c => c.Type)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.TypeId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Type>().HasData(
                new Type { Id = 1, Name = "Candy",});

            builder.Entity<Type>().HasData(
                new Type { Id = 2, Name = "Fizzy Drinks", });

            builder.Entity<Type>().HasData(
                new Type { Id = 3, Name = "Sour", });

           


            base.OnModelCreating(builder);
        }
    }
}