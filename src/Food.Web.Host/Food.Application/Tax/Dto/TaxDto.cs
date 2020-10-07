using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Food.Tax.Dto
{
    [AutoMapFrom(typeof(Ordering.Dictionaries.Tax))]
    public class TaxDto : EntityDto<int>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
