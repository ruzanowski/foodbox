using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Food.Authorization;
using Food.Tax.Dto;

namespace Food.Tax
{
    [AbpAuthorize(PermissionNames.Pages_Taxes)]
    public class TaxAppService :
        AsyncCrudAppService<Ordering.Dictionaries.Tax, TaxDto, int, PagedResultRequestDto, CreateTaxDto, TaxDto>, ITaxAppService
    {
        public TaxAppService(IRepository<Ordering.Dictionaries.Tax, int> repository) : base(repository)
        {
        }
    }
}
