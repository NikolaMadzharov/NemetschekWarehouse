using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NemetschekWarehouse.Infrastructure.Data.Entities;
using Type = NemetschekWarehouse.Infrastructure.Data.Entities.Type;

namespace NemetschekWarehouse.Infrastructure.data
{
    public class WarehouseDb : IdentityDbContext
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


           


            base.OnModelCreating(builder);
        }
    }
}