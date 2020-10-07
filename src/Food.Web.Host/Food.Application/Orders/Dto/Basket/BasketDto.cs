using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Food.Orders.Dto.OrderBasketItem;

namespace Food.Orders.Dto.Basket
{
    [AutoMapFrom(typeof(Ordering.Basket))]
    public class BasketDto : EntityDto<int>
    {
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscounts { get; set; }
        public decimal TotalCutleryPrice { get; set; }
        public decimal TotalDeliveryPrice { get; set; }
        public IEnumerable<OrderBasketItemDto> Items { get; set; }
    }
}
