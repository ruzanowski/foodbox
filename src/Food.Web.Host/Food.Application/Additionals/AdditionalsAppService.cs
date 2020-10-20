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
    public class AdditionalsAppService :
        AsyncCrudAppService<Ordering.Dictionaries.Additionals, AdditionalsDto, int, PagedResultRequestDto, CreateAdditionalsDto, AdditionalsDto>, IAdditionalsAppService
    {        private readonly IRepository<Ordering.Dictionaries.Tax> _taxRepository;

        public AdditionalsAppService(IRepository<Ordering.Dictionaries.Additionals, int> repository, IRepository<Ordering.Dictionaries.Tax> taxRepository) : base(repository)
        {
            _taxRepository = taxRepository;
        }

        [AbpAuthorize(PermissionNames.Pages_Additionals)]
        public override async Task<AdditionalsDto> CreateAsync(CreateAdditionalsDto input)
        {
            CheckCreatePermission();

            var tax = await _taxRepository.GetAsync(input.TaxId);

            if (tax == null)
            {
                throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Additionals), input.TaxId);
            }

            var product = ObjectMapper.Map<Ordering.Dictionaries.Additionals>(input);

            product.Tax ??= tax;

            await Repository.InsertAsync(product);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(product);
        }

        [AbpAuthorize(PermissionNames.Pages_Additionals)]
        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Additionals)]
        public override async Task<AdditionalsDto> UpdateAsync(AdditionalsDto input)
        {
            CheckCreatePermission();

            var tax = await _taxRepository.GetAsync(input.TaxId);

            if (tax == null)
            {
                throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Additionals), input.TaxId);
            }

            input.Tax = null;
            var product = ObjectMapper.Map<Ordering.Dictionaries.Additionals>(input);

            product.Tax ??= tax;

            await Repository.UpdateAsync(product);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(product);
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
