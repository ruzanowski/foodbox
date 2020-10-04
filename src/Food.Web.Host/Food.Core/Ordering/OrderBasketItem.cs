using System.Collections.Generic;
using Abp.Domain.Entities;

namespace Food.Ordering
{
    public class OrderBasketItem : Entity<int>
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int TotalDays { get; set; }
        public bool WeekendsIncluded { get; set; }

        public decimal PriceBought { get; set; }
        public decimal DiscountApplied { get; set; }

        public IEnumerable<DeliveryTime> DeliveryTimes { get; set; }
    }
}
