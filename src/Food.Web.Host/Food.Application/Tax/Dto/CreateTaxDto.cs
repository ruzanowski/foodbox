using Abp.AutoMapper;

namespace Food.Tax.Dto
{
    [AutoMapTo(typeof(Ordering.Dictionaries.Tax))]
    public class CreateTaxDto
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
