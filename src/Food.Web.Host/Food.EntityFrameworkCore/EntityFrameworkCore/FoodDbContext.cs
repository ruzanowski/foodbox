using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Food.Authorization.Roles;
using Food.Authorization.Users;
using Food.MultiTenancy;
using Food.Ordering;

namespace Food.EntityFrameworkCore
{
    public class FoodDbContext : AbpZeroDbContext<Tenant, Role, User, FoodDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public FoodDbContext(DbContextOptions<FoodDbContext> options)
            : base(options)
        {
        }
    }
}
