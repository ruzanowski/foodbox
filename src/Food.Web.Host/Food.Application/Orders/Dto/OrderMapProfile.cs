using AutoMapper;
using Food.Ordering;
using Food.Orders.Dto.Basket;
using Food.Orders.Dto.DeliveryTime;
using Food.Orders.Dto.Order;
using Food.Orders.Dto.OrderBasketItem;
using Food.Orders.Dto.OrderForm;
using Food.Payments.Dto;
using Food.Product.Dto;

namespace Food.Orders.Dto
{
    public class OrderMapProfile : Profile
    {
        public OrderMapProfile()
        {
            CreateMap<OrderDto, Ordering.Order>();
            CreateMap<CreateOrderDto, Ordering.Order>();

            CreateMap<OrderFormDto, Ordering.OrderForm>();
            CreateMap<CreateOrderFormDto, Ordering.OrderForm>();

            CreateMap<OrderBasketItemDto, Ordering.OrderBasketItem>();
            CreateMap<CreateOrderBasketItemDto, Ordering.OrderBasketItem>();

            CreateMap<BasketDto, Ordering.Basket>();
            CreateMap<CreateBasketDto, Ordering.Basket>();

            CreateMap<PaymentDto, Payment>();
            CreateMap<CreatePaymentDto, Payment>();

            CreateMap<ProductDto, Ordering.Product>();
            CreateMap<CreateProductDto, Ordering.Product>();

            CreateMap<DeliveryTimeDto, Ordering.DeliveryTime>();
            CreateMap<CreateDeliveryTimeDto, Ordering.DeliveryTime>();
        }
    }
}
