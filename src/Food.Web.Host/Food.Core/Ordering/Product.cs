using Abp.Domain.Entities;
using Food.Ordering.Dictionaries;

namespace Food.Ordering
{
    public class Product : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceNet { get; set; }
        public decimal PriceGross => PriceNet * (1 + Tax?.Value ?? 0);
        public string ImagePath { get; set; }
        public int TaxId { get; set; }
        public Tax Tax { get; set; }
    }
}
