using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Food.Tax.Dto;

namespace Food.Tax
{
    public interface ITaxAppService : IAsyncCrudAppService<TaxDto, int, PagedResultRequestDto, CreateTaxDto, TaxDto>
    {
    }
}
