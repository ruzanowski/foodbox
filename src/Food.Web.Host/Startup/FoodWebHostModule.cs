using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Food.Core;
using Food.Core.Configuration;

namespace Food.Web.Host.Startup
{
    [DependsOn(
       typeof(FoodWebCoreModule))]
    public class FoodWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FoodWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FoodWebHostModule).GetAssembly());
        }
    }
}
