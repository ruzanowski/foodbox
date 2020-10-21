using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Food.Ordering.Dictionaries;
using Food.Tax.Dto;

namespace Food.Additionals.Dto
{
    [AutoMapFrom(typeof(Ordering.Dictionaries.Additionals))]
    public class AdditionalsDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public AdditionalsType Type { get; set; }
        [Required]
        [Range(0,1000)]
        public decimal ValueGross { get; set; }
        public int TaxId { get; set; }
        [Required]
        [Range(1,1000)]
        public TaxDto Tax { get; set; }
    }
}
