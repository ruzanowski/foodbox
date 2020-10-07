using System.Collections.Generic;
using Abp.Domain.Entities;
using Food.Ordering.Dictionaries;

namespace Food.Ordering
{
    public class OrderBasketItem : Entity<int>
    {
        public int ProductId { get; set; }
        public int? CaloriesId { get; set; }
        public int? CutleryFeeId { get; set; }
        private int? DiscountId { get; set; }
        private int? DeliveryFeeId { get; set; }

        #region prices

        // Static Prices
        private decimal TaxProductPercentBought { get; set; }
        private decimal PriceNetBought { get; set; }
        private decimal DiscountPercentBought { get; set; }
        private decimal CutleryNetFeeBought { get; set; }
        private decimal CutleryFeeTaxPercentBought { get; set; }
        private decimal DeliveryNetFeeBought { get; set; }
        private decimal DeliveryFeeTaxPercentBought { get; set; }

        // Calculated Prices
        public decimal PriceDiscountAppliedBought => PriceGrossBought * DiscountPercentBought;
        public decimal PriceGrossBought => PriceNetBought * (1 + TaxProductPercentBought);
        public decimal DeliveryFeeGrossBought => DeliveryNetFeeBought * (1 + DeliveryFeeTaxPercentBought);
        public decimal CutleryFeeGrossFeeBought => CutleryNetFeeBought * (1 + CutleryFeeTaxPercentBought);
        public decimal TotalPriceBought =>
            PriceGrossBought * (1 + DiscountPercentBought)
            + DeliveryFeeGrossBought
            + CutleryFeeGrossFeeBought;

        #endregion

        public Product Product { get; set; }
        public Calories Calories { get; set; }
        public Discount Discount { get; set; }
        public Additionals Cutlery { get; set; }
        public Additionals Delivery { get; set; }
        // might be selected price of delivery fee if calculated internally how many kilometers we do have

        public int Count { get; set; }
        public bool? WeekendsIncluded { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<DeliveryTime> DeliveryTimes { get; set; }

        public void CalculatePrices(
            int? deliveryFeeId,
            int? discountFeeId)
        {
            DeliveryFeeId = deliveryFeeId;
            DiscountId = discountFeeId;

            PriceNetBought = Product.PriceNet;
            TaxProductPercentBought = Product.Tax.Value;

            DiscountPercentBought = Discount?.Value ?? 0;

            DeliveryNetFeeBought = Delivery?.Value ?? 0;
            DeliveryFeeTaxPercentBought = Delivery?.Tax.Value ?? 0 ;

            CutleryNetFeeBought = Cutlery?.Value ?? 0;
            CutleryFeeTaxPercentBought = Cutlery?.Tax.Value ?? 0;
        }
    }
}
