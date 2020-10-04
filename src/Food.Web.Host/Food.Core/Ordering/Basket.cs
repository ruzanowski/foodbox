using System.Collections.Generic;
using Abp.Domain.Entities;

namespace Food.Ordering
{
    public class Basket : Entity<int>
    {
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscounts { get; set; }

        public IEnumerable<OrderBasketItem> Items { get; set; }
    }
}
