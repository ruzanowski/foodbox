using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public uint ProductId { get; set; }
        public uint? CaloriesId { get; set; }
        public uint? DiscountId { get; set; }
        public uint? CutleryId { get; set; }
        public uint? DeliveryId { get; set; }
        public ProductDto Product { get; set; }
        public CaloriesDto Calories { get; set; }
        public DiscountDto Discount { get; set; }
        public AdditionalsDto Cutlery { get; set; }
        public AdditionalsDto Delivery { get; set; }

        [Required]
        public uint Count { get; set; }
        public bool WeekendsIncluded { get; set; }
        public string Remarks { get; set; }
        public int TotalDays => DeliveryTimes.Count();

        public decimal PriceGrossBought { get; set; } // readonly
        public decimal DeliveryFeeGrossBought { get; set; } // readonly
        public decimal CutleryFeeGrossFeeBought { get; set; } // readonly
        public decimal TotalPriceBought { get; set; } // readonly
        [Required]

        public IEnumerable<DeliveryTimeDto> DeliveryTimes { get; set; }
    }
}
