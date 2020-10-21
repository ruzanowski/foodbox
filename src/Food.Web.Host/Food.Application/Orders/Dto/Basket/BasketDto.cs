using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Food.Orders.Dto.OrderBasketItem;

namespace Food.Orders.Dto.Basket
{
    [AutoMapFrom(typeof(Ordering.Basket))]
    public class BasketDto : EntityDto<int>
    {
        public decimal TotalPrice { get; set; } //readonly
        public decimal TotalDiscounts { get; set; } //readonly
        public decimal TotalCutleryPrice { get; set; } //readonly
        public decimal TotalDeliveryPrice { get; set; } //readonly
        [Required]
        public IEnumerable<OrderBasketItemDto> Items { get; set; }
    }
}
