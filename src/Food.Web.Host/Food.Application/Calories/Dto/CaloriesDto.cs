using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Food.Calories.Dto
{
    [AutoMapFrom(typeof(Ordering.Dictionaries.Calories))]
    public class CaloriesDto : EntityDto<int>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal AdditionToPrice { get; set; }
    }
}
