using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Food.Ordering.Dictionaries;

namespace Food.Additionals.Dto
{
    [AutoMapTo(typeof(Ordering.Dictionaries.Additionals))]
    public class CreateAdditionalsDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0,1000)]
        public decimal Value { get; set; }
        [Required]
        public AdditionalsType Type { get; set; }
        [Required]
        [Range(1,1000)]
        public int TaxId { get; set; }
    }
}
