using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Entities;
using Food.Ordering.Dictionaries;

namespace Food.Ordering
{
    public class OrderBasketItem : Entity<int>
    {
        public int ProductId { get; set; }
        public int? CaloriesId { get; set; }
        public int? CutleryFeeId { get; set; }
        public int? DiscountId { get; set; }
        public int? DeliveryFeeId { get; set; }

        #region prices

        // Static Prices
        public decimal TaxProductPercentBought { get; private set; }
        public decimal PriceNetBought { get;  private set; }
        public decimal DiscountPercentBought { get;  private set; }
        public decimal CountBought { get;  private set; }
        public decimal CaloriesAdditionalPriceBought { get;  private set; }
        public decimal DeliveryTimesCountBought { get; private set; }
        public decimal CutleryNetFeeBought { get; private set; }
        public decimal CutleryFeeTaxPercentBought { get;  private set; }
        public decimal DeliveryNetFeeBought { get; private set; }
        public decimal DeliveryFeeTaxPercentBought { get; private set; }

        // Calculated Prices
        public decimal PriceDiscountAppliedBought => PriceGrossBought * DiscountPercentBought;
        public decimal PriceGrossBought => PriceNetBought * (1 + TaxProductPercentBought);
        public decimal DeliveryFeeGrossBought => DeliveryNetFeeBought * (1 + DeliveryFeeTaxPercentBought)
                                                                      * CountBought
                                                                      * DeliveryTimesCountBought;
        public decimal CutleryFeeGrossFeeBought => CutleryNetFeeBought
                                                   * (1 + CutleryFeeTaxPercentBought)
                                                   * CountBought
                                                   * DeliveryTimesCountBought;
        public decimal TotalPriceBought =>
            PriceGrossBought
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

        public void SetValues(int? deliveryFeeId,
            int? discountFeeId)
        {
            DeliveryFeeId = deliveryFeeId;
            DiscountId = discountFeeId;
        }

        public void CalculatePrices(
            int? deliveryFeeId,
            int? discountFeeId)
        {
            DiscountPercentBought = Discount?.Value ?? 0;

            DeliveryNetFeeBought = Delivery?.Value ?? 0;
            DeliveryFeeTaxPercentBought = Delivery?.Tax.Value ?? 0 ;

            CutleryNetFeeBought = Cutlery?.Value ?? 0;
            CutleryFeeTaxPercentBought = Cutlery?.Tax.Value ?? 0;

            PriceNetBought = NetPrice();
            CaloriesAdditionalPriceBought = Calories.AdditionToPrice;
            CountBought = Count;
            DeliveryTimesCountBought = DeliveryTimes.Count();
            TaxProductPercentBought = Product.Tax.Value;
        }

        private decimal NetPrice() => (Product.PriceNet + Calories.AdditionToPrice)
                                      * (1 - DiscountPercentBought)
                                      * Count
                                      * DeliveryTimes.Count();
    }
}
