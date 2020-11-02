using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Food.Authorization.Roles;
using Food.Authorization.Users;
using Food.Cache;
using Food.MultiTenancy;
using Food.Ordering;
using Food.Ordering.Dictionaries;

namespace Food.EntityFrameworkCore
{
    public class FoodDbContext : AbpZeroDbContext<Tenant, Role, User, FoodDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Calories> Calories { get; set; }
        public DbSet<Additionals> Additionals { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<CachedItem> CachedItems { get; set; }

        public FoodDbContext(DbContextOptions<FoodDbContext> options)
            : base(options)
        {
        }
    }
}
