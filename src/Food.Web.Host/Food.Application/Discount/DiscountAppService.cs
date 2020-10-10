using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Food.Authorization;
using Food.Discount.Dto;

namespace Food.Discount
{
    public class DiscountAppService :
        AsyncCrudAppService<Ordering.Dictionaries.Discount, DiscountDto, int, PagedResultRequestDto, CreateDiscountDto, DiscountDto>, IDiscountAppService
    {
        public DiscountAppService(IRepository<Ordering.Dictionaries.Discount, int> repository) : base(repository)
        {
        }

        [AbpAuthorize(PermissionNames.Pages_Discounts)]
        public override Task<DiscountDto> CreateAsync(CreateDiscountDto input)
        {
            return base.CreateAsync(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Discounts)]
        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Discounts)]
        public override Task<DiscountDto> UpdateAsync(DiscountDto input)
        {
            return base.UpdateAsync(input);
        }
    }
}
