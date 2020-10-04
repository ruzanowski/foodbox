using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Food.Product.Dto
{
    [AutoMapFrom(typeof(Ordering.Product))]
    public class ProductDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
