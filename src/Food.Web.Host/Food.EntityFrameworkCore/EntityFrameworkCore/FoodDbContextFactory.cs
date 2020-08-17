using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Food.Configuration;
using Food.Web;

namespace Food.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FoodDbContextFactory : IDesignTimeDbContextFactory<FoodDbContext>
    {
        public FoodDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FoodDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            FoodDbContextConfigurer.Configure(builder, configuration.GetConnectionString(FoodConsts.ConnectionStringName));

            return new FoodDbContext(builder.Options);
        }
    }
}
