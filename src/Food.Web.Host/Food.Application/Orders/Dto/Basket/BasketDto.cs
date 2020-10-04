using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Food.Orders.Dto.OrderBasketItem;

namespace Food.Orders.Dto.Basket
{
    [AutoMapFrom(typeof(Ordering.Basket))]
    public class BasketDto : EntityDto<int>
    {
        public decimal TotalPrice => Items.Sum(item => item.Count * item.Product?.Price ?? 0);

        public decimal TotalDiscounts => 0;
        public IEnumerable<OrderBasketItemDto> Items { get; set; }
    }
}
