using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Food.Calories.Dto
{
    [AutoMapFrom(typeof(Ordering.Dictionaries.Calories))]
    public class CaloriesDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,10000)]
        public decimal Value { get; set; }
        [Required]
        [Range(0,10000)]
        public decimal AdditionToPrice { get; set; }
    }
}
