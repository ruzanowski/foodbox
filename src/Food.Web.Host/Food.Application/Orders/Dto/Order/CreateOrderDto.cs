using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Food.Orders.Dto.Basket;
using Food.Orders.Dto.OrderForm;

namespace Food.Orders.Dto.Order
{
    [AutoMapTo(typeof(Ordering.Order))]
    public class CreateOrderDto
    {
        [Required]
        public CreateOrderFormDto Form { get; set; }
        [Required]
        public CreateBasketDto Basket { get; set; }
    }
}
