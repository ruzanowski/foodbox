using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using Food.EntityFrameworkCore.Seed.Additionals;
using Food.EntityFrameworkCore.Seed.Calories;
using Food.EntityFrameworkCore.Seed.Host;
using Food.EntityFrameworkCore.Seed.Order;
using Food.EntityFrameworkCore.Seed.Products;
using Food.EntityFrameworkCore.Seed.Tax;
using Food.EntityFrameworkCore.Seed.Tenants;

namespace Food.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        public static void SeedHostDb(IIocResolver iocResolver)
        {
            WithDbContext<FoodDbContext>(iocResolver, SeedHostDb);
        }

        public static void SeedHostDb(FoodDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            // Host seed
            new InitialHostDbBuilder(context).Create();

            // Default tenant seed (in host database).
            new DefaultTaxBuilder(context).Create();
            new DefaultProductsBuilder(context).Create();
            new DefaultAdditionalsBuilder(context).Create();
            new DefaultCaloriesBuilder(context).Create();
            new DefaultOrderBuilder(context).Create();
            new DefaultTenantBuilder(context).Create();
            new TenantRoleAndUserBuilder(context, 1).Create();
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}
