using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Food.Ordering;
using Food.Product.Dto;
using Microsoft.EntityFrameworkCore;

namespace Food.Product
{
    public class ProductAppService : AsyncCrudAppService<Ordering.Product, ProductDto, int, PagedResultRequestDto, CreateProductDto, ProductDto>
    {
        private readonly IRepository<Ordering.Dictionaries.Tax> _taxRepository;
        public ProductAppService(IRepository<Ordering.Product, int> repository,
            IRepository<Ordering.Dictionaries.Tax> taxRepository) : base(repository)
        {
            _taxRepository = taxRepository;
        }

        public override async Task<ProductDto> CreateAsync(CreateProductDto input)
        {
            CheckCreatePermission();

            var tax = await _taxRepository.GetAsync(input.TaxId);

            if (tax == null)
            {
                throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Tax), input.TaxId);
            }

            var order = ObjectMapper.Map<Ordering.Product>(input);

            order.Tax ??= tax;

            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(order);
        }

        protected override IQueryable<Ordering.Product> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(x=>x.Tax);
        }

        protected override async Task<Ordering.Product> GetEntityByIdAsync(int id)
        {
            var order = await Repository.GetAllIncluding(x=>x.Tax)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                throw new EntityNotFoundException(typeof(Order), id);
            }

            return order;
        }
    }
}
