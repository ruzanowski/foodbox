using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Food.Discount.Dto
{
    [AutoMapFrom(typeof(Ordering.Dictionaries.Discount))]
    public class DiscountDto : EntityDto<int>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int MinimumDays { get; set; }
    }
}
