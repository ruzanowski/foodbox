using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using Food.Orders.Dto.DeliveryTime;

namespace Food.Orders.Dto.OrderBasketItem
{
    [AutoMapFrom(typeof(Ordering.OrderBasketItem))]
    public class OrderBasketItemDto
    {
        public int ProductId { get; set; }
        public Ordering.Product Product { get; set; }
        public int Count { get; set; }
        public int TotalDays => DeliveryTimes.Count();
        public bool WeekendsIncluded { get; set; }
        public IEnumerable<DeliveryTimeDto> DeliveryTimes { get; set; }
    }
}
