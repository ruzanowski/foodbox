using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Food.EntityFrameworkCore;
using Food.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Food.Web.Tests
{
    [DependsOn(
        typeof(FoodWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class FoodWebTestModule : AbpModule
    {
        public FoodWebTestModule(FoodEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FoodWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FoodWebMvcModule).Assembly);
        }
    }
}