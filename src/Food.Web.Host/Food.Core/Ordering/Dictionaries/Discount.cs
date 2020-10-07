using Abp.Domain.Entities;

namespace Food.Ordering.Dictionaries
{
    public class Discount : Entity<int>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int MinimumDays { get; set; }
    }
}
