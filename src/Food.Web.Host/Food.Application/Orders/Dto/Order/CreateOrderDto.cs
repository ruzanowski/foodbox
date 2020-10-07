using Abp.AutoMapper;
using Food.Orders.Dto.Basket;
using Food.Orders.Dto.OrderForm;

namespace Food.Orders.Dto.Order
{
    [AutoMapTo(typeof(Ordering.Order))]
    public class CreateOrderDto
    {
        public CreateOrderFormDto Form { get; set; }
        public CreateBasketDto Basket { get; set; }
    }
}
