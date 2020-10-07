using Abp.Domain.Entities;

namespace Food.Ordering.Dictionaries
{
    public class Additionals : Entity<int>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public AdditionalsType Type { get; set; }

        public int TaxId { get; set; }
        public Tax Tax { get; set; }
    }

    public enum AdditionalsType
    {
        Cutlery,
        Delivery
    }
}
