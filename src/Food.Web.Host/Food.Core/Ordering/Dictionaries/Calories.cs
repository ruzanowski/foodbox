using Abp.Domain.Entities;

namespace Food.Ordering.Dictionaries
{
    public class Calories : Entity<int>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
