using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace Food.Tax.Dto
{
    [AutoMapTo(typeof(Ordering.Dictionaries.Tax))]
    public class CreateTaxDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,1)]
        public decimal Value { get; set; }
    }
}
