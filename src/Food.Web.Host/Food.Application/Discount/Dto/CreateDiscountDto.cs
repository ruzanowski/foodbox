using Abp.AutoMapper;

namespace Food.Discount.Dto
{
    [AutoMapTo(typeof(Ordering.Dictionaries.Discount))]
    public class CreateDiscountDto
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int MinimumDays { get; set; }
    }
}
