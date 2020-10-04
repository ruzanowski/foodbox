using System.Collections.Generic;
using Abp.AutoMapper;
using Food.Orders.Dto.DeliveryTime;

namespace Food.Orders.Dto.OrderBasketItem
{
    [AutoMapTo(typeof(Ordering.OrderBasketItem))]
    public class CreateOrderBasketItemDto
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public bool WeekendsIncluded { get; set; }
        public IEnumerable<CreateDeliveryTimeDto> DeliveryTimes { get; set; }
    }
}
