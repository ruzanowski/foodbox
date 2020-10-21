using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Food.Tax.Dto
{
    [AutoMapFrom(typeof(Ordering.Dictionaries.Tax))]
    public class TaxDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,1)]
        public decimal Value { get; set; }
    }
}
