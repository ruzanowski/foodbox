using Abp.AutoMapper;

namespace Food.Product.Dto
{
    [AutoMapTo(typeof(Ordering.Product))]
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceNet { get; set; }
        public string ImagePath { get; set; }
        public int TaxId { get; set; }
    }
}
