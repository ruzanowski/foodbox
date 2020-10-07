using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Food.Tax.Dto;

namespace Food.Additionals.Dto
{
    [AutoMapFrom(typeof(Ordering.Dictionaries.Additionals))]
    public class AdditionalsDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public TaxDto Tax { get; set; }
    }
}
