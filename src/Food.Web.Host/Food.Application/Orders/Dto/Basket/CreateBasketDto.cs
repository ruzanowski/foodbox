using System.Collections.Generic;
using Abp.AutoMapper;
using Food.Orders.Dto.OrderBasketItem;

namespace Food.Orders.Dto.Basket
{
    [AutoMapTo(typeof(Ordering.Basket))]
    public class CreateBasketDto
    {
        public IEnumerable<CreateOrderBasketItemDto> Items { get; set; }
    }
}
