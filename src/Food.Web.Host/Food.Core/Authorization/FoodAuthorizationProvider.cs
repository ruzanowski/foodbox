using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Food.Authorization
{
    public class FoodAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Orders, L("Orders"));
            context.CreatePermission(PermissionNames.Pages_Payments, L("Payments"));
            context.CreatePermission(PermissionNames.Pages_Products, L("Products"));
            context.CreatePermission(PermissionNames.Pages_Taxes, L("Tax"));
            context.CreatePermission(PermissionNames.Pages_Additionals, L("Additionals"));
            context.CreatePermission(PermissionNames.Pages_Discounts, L("Discounts"));
            context.CreatePermission(PermissionNames.Pages_Calories, L("Calories"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, FoodConsts.LocalizationSourceName);
        }
    }
}
