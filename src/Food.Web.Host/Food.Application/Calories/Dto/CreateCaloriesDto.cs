using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace Food.Calories.Dto
{
    [AutoMapTo(typeof(Ordering.Dictionaries.Calories))]
    public class CreateCaloriesDto
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
