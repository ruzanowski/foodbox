using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Food.Additionals;
using Food.Additionals.Dto;
using Food.Authorization.Users;
using Food.Calories;
using Food.Calories.Dto;
using Food.Discount;
using Food.Discount.Dto;
using Food.MultiTenancy;
using Food.Product;
using Food.Product.Dto;
using Food.Tax;
using Food.Tax.Dto;

namespace Food
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class FoodAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }
        public UserManager UserManager { get; set; }
        public CaloriesAppService CaloriesService { get; set; }
        public ProductAppService ProductService { get; set; }
        public DiscountAppService DiscountService { get; set; }
        public AdditionalsAppService AdditionalsService { get; set; }
        public TaxAppService TaxService { get; set; }

        protected FoodAppServiceBase(
            CaloriesAppService caloriesService,
            ProductAppService productService,
            DiscountAppService discountService,
            AdditionalsAppService additionalsService,
            TaxAppService taxService)
        {
            CaloriesService = caloriesService;
            ProductService = productService;
            DiscountService = discountService;
            AdditionalsService = additionalsService;
            TaxService = taxService;
            LocalizationSourceName = FoodConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected virtual async Task<IReadOnlyList<CaloriesDto>> GetCalories()
        {
            return (await CaloriesService.GetAllAsync(new PagedResultRequestDto()
            {
                SkipCount = 0,
                MaxResultCount = 999
            })).Items;
        }
        protected virtual async Task<IReadOnlyList<ProductDto>> GetProducts()
        {
            return (await ProductService.GetAllAsync(new PagedResultRequestDto()
            {
                SkipCount = 0,
                MaxResultCount = 999
            })).Items;
        }
        protected virtual async Task<IReadOnlyList<DiscountDto>> GetDiscounts()
        {
            return (await DiscountService.GetAllAsync(new PagedResultRequestDto()
            {
                SkipCount = 0,
                MaxResultCount = 999
            })).Items;
        }
        protected virtual async Task<IReadOnlyList<AdditionalsDto>> GetAdditionals()
        {
            return (await AdditionalsService.GetAllAsync(new PagedResultRequestDto()
            {
                SkipCount = 0,
                MaxResultCount = 999
            })).Items;
        }
        protected virtual async Task<IReadOnlyList<TaxDto>> GetTaxes()
        {
            return (await TaxService.GetAllAsync(new PagedResultRequestDto()
            {
                SkipCount = 0,
                MaxResultCount = 999
            })).Items;
        }
    }
}
