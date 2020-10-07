using Abp.Domain.Entities;

namespace Food.Ordering.Dictionaries
{
    public class Tax : Entity<int>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}