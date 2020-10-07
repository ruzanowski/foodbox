using Abp.AutoMapper;

namespace Food.Additionals.Dto
{
    [AutoMapTo(typeof(Ordering.Dictionaries.Additionals))]
    public class CreateAdditionalsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int TaxId { get; set; }
    }
}
