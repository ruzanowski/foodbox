using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Food.Orders.Dto.DeliveryTime;

namespace Food.Orders.Dto.OrderBasketItem
{
    [AutoMapTo(typeof(Ordering.OrderBasketItem))]
    public class CreateOrderBasketItemDto
    {
        [Required]
        public uint ProductId { get; set; }
        public uint Count { get; set; }
        public bool WeekendsIncluded { get; set; }
        public uint? CaloriesId { get; set; }
        public uint? CutleryFeeId { get; set; }
        public IEnumerable<CreateDeliveryTimeDto> DeliveryTimes { get; set; }
    }
}
