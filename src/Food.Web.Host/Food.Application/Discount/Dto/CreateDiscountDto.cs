using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace Food.Discount.Dto
{
    [AutoMapTo(typeof(Ordering.Dictionaries.Discount))]
    public class CreateDiscountDto
    {
        [Required]
        public string Name { get; set; }
        [Range(0,1)]
        [Required]
        public decimal Value { get; set; }
        [Required]
        public uint MinimumDays { get; set; }
    }
}
