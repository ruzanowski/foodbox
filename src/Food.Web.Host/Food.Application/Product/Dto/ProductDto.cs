using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Food.Tax.Dto;

namespace Food.Product.Dto
{
    [AutoMapFrom(typeof(Ordering.Product))]
    public class ProductDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceNet { get; set; }
        public decimal PriceGross { get; set; }
        public string ImagePath { get; set; }
        public TaxDto Tax { get; set; }
    }
}
