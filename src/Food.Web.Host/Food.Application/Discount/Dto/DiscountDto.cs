using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Food.Discount.Dto
{
    [AutoMapFrom(typeof(Ordering.Dictionaries.Discount))]
    public class DiscountDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,1)]
        public decimal Value { get; set; }
        [Required]
        public uint MinimumDays { get; set; }
    }
}
