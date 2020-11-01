using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Food.Additionals;
using Food.Calories;
using Food.Configuration.Dto;
using Food.Discount;
using Food.Product;
using Food.Tax;

namespace Food.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FoodAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme,
                input.Theme);
        }

        public ConfigurationAppService(CaloriesAppService caloriesService, ProductAppService productService,
            DiscountAppService discountService, AdditionalsAppService additionalsService, TaxAppService taxService) :
            base(caloriesService, productService, discountService, additionalsService, taxService)
        {
        }
    }
}
