using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using Food.Additionals.Dto;
using Food.Calories.Dto;
using Food.Discount.Dto;
using Food.Orders.Dto.DeliveryTime;
using Food.Product.Dto;

namespace Food.Orders.Dto.OrderBasketItem
{
    [AutoMapFrom(typeof(Ordering.OrderBasketItem))]
    public class OrderBasketItemDto
    {
        public int ProductId { get; set; }
        public int? CaloriesId { get; set; }
        public int? DiscountId { get; set; }
        public int? CutleryId { get; set; }
        public int? DeliveryId { get; set; }
        public ProductDto Product { get; set; }
        public CaloriesDto Calories { get; set; }
        public DiscountDto Discount { get; set; }
        public AdditionalsDto Cutlery { get; set; }
        public AdditionalsDto Delivery { get; set; }

        public int Count { get; set; }
        public bool WeekendsIncluded { get; set; }
        public string Remarks { get; set; }
        public int TotalDays => DeliveryTimes.Count();

        public decimal PriceGrossBought { get; set; }
        public decimal DeliveryFeeGrossBought { get; set; }
        public decimal CutleryFeeGrossFeeBought { get; set; }
        public decimal TotalPriceBought { get; set; }
        public IEnumerable<DeliveryTimeDto> DeliveryTimes { get; set; }
    }
}
