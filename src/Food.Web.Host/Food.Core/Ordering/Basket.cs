using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Entities;

namespace Food.Ordering
{
    public class Basket : Entity<int>
    {
        public decimal TotalPrice => Items.Sum(item => item.TotalPriceBought);
        public decimal TotalCutleryPrice => Items.Sum(item => item.CutleryFeeGrossFeeBought);
        public decimal TotalDeliveryPrice => Items.Sum(item => item.DeliveryFeeGrossBought);
        public decimal TotalDiscounts => Items.Sum(item => item.PriceDiscountAppliedBought);

        public IEnumerable<OrderBasketItem> Items { get; set; }
        public string CreatorIp { get; set; }
    }
}
