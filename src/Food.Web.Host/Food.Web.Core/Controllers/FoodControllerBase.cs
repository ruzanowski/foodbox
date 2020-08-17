using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Food.Core.Controllers
{
    public abstract class FoodControllerBase: AbpController
    {
        protected FoodControllerBase()
        {
            LocalizationSourceName = FoodConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
