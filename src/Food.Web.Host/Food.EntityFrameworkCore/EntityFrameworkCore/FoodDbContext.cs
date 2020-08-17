using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Food.Authorization.Roles;
using Food.Authorization.Users;
using Food.MultiTenancy;

namespace Food.EntityFrameworkCore
{
    public class FoodDbContext : AbpZeroDbContext<Tenant, Role, User, FoodDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public FoodDbContext(DbContextOptions<FoodDbContext> options)
            : base(options)
        {
        }
    }
}
