using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Food.Additionals.Dto;
using Food.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Food.Additionals
{
    [AbpAuthorize(PermissionNames.Pages_Additionals)]
    public class AdditionalsAppService :
        AsyncCrudAppService<Ordering.Dictionaries.Additionals, AdditionalsDto, int, PagedResultRequestDto, CreateAdditionalsDto, AdditionalsDto>, IAdditionalsAppService
    {
        public AdditionalsAppService(IRepository<Ordering.Dictionaries.Additionals, int> repository) : base(repository)
        {
        }

        protected override IQueryable<Ordering.Dictionaries.Additionals> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Tax);
        }

        protected override async Task<Ordering.Dictionaries.Additionals> GetEntityByIdAsync(int id)
        {
            var order = await Repository.GetAllIncluding(x=>x.Tax)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Additionals), id);
            }

            return order;
        }
    }
}
