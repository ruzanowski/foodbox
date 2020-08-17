using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Food.EntityFrameworkCore
{
    public static class FoodDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FoodDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FoodDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
