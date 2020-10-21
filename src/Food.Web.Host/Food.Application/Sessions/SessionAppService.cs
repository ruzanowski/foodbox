using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Auditing;
using Food.Additionals;
using Food.Calories;
using Food.Discount;
using Food.Product;
using Food.Sessions.Dto;
using Food.Tax;

namespace Food.Sessions
{
    public class SessionAppService : FoodAppServiceBase, ISessionAppService
    {
        [DisableAuditing]
        public async Task<GetInitialInformation> GetCurrentLoginInformations()
        {
            var output = new GetInitialInformation
            {
                Application = new ApplicationInfoDto
                {
                    Version = AppVersionHelper.Version,
                    ReleaseDate = AppVersionHelper.ReleaseDate,
                    Features = new Dictionary<string, bool>()
                }
            };

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = ObjectMapper.Map<TenantLoginInfoDto>(await GetCurrentTenantAsync());
            }

            if (AbpSession.UserId.HasValue)
            {
                output.User = ObjectMapper.Map<UserLoginInfoDto>(await GetCurrentUserAsync());
            }

            output.Taxes = await GetTaxes();
            output.Additionals = await GetAdditionals();
            output.Calories = await GetCalories();
            output.Discounts = await GetDiscounts();
            output.Products = await GetProducts();
            return output;
        }

        public SessionAppService(CaloriesAppService caloriesService, ProductAppService productService, DiscountAppService discountService, AdditionalsAppService additionalsService, TaxAppService taxService) : base(caloriesService, productService, discountService, additionalsService, taxService)
        {
        }
    }
}
