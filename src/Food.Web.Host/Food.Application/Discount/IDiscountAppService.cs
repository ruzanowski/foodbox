using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Food.Discount.Dto;

namespace Food.Discount
{
    public interface IDiscountAppService : IAsyncCrudAppService<DiscountDto, int, PagedResultRequestDto, CreateDiscountDto, DiscountDto>
    {
    }
}