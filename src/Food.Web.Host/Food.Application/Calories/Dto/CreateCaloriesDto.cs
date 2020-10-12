using Abp.AutoMapper;

namespace Food.Calories.Dto
{
    [AutoMapTo(typeof(Ordering.Dictionaries.Calories))]
    public class CreateCaloriesDto
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal AdditionToPrice { get; set; }
    }
}
