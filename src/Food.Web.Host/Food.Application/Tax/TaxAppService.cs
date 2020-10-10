using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Food.Authorization;
using Food.Tax.Dto;

namespace Food.Tax
{
    public class TaxAppService :
        AsyncCrudAppService<Ordering.Dictionaries.Tax, TaxDto, int, PagedResultRequestDto, CreateTaxDto, TaxDto>, ITaxAppService
    {
        public TaxAppService(IRepository<Ordering.Dictionaries.Tax, int> repository) : base(repository)
        {
        }
        [AbpAuthorize(PermissionNames.Pages_Taxes)]
        public override Task<TaxDto> CreateAsync(CreateTaxDto input)
        {
            return base.CreateAsync(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Taxes)]
        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Taxes)]
        public override Task<TaxDto> UpdateAsync(TaxDto input)
        {
            return base.UpdateAsync(input);
        }
    }
}
