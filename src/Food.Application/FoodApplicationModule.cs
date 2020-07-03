using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Food.Authorization;

namespace Food
{
    [DependsOn(
        typeof(FoodCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FoodApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FoodAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FoodApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
