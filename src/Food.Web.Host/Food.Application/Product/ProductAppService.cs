using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Food.Product.Dto;

namespace Food.Product
{
    public class ProductAppService : AsyncCrudAppService<Ordering.Product, ProductDto, int, PagedResultRequestDto, CreateProductDto, ProductDto>
    {
        public ProductAppService(IRepository<Ordering.Product, int> repository) : base(repository)
        {
        }
    }
}
