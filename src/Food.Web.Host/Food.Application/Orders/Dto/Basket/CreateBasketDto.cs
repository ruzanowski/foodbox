using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Food.Orders.Dto.OrderBasketItem;

namespace Food.Orders.Dto.Basket
{
    [AutoMapTo(typeof(Ordering.Basket))]
    public class CreateBasketDto
    {
        [Required]
        public IEnumerable<CreateOrderBasketItemDto> Items { get; set; }
    }
}
