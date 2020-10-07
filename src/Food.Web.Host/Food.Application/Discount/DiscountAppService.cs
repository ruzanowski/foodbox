using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Food.Authorization;
using Food.Discount.Dto;

namespace Food.Discount
{
    [AbpAuthorize(PermissionNames.Pages_Discounts)]
    public class DiscountAppService :
        AsyncCrudAppService<Ordering.Dictionaries.Discount, DiscountDto, int, PagedResultRequestDto, CreateDiscountDto, DiscountDto>, IDiscountAppService
    {
        public DiscountAppService(IRepository<Ordering.Dictionaries.Discount, int> repository) : base(repository)
        {
        }
    }
}
