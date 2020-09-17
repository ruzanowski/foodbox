using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Food.EntityFrameworkCore
{
    public static class FoodDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FoodDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FoodDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
