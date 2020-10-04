using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Food.Orders.Dto.Basket;
using Food.Orders.Dto.OrderForm;
using Food.Payments.Dto;
using Newtonsoft.Json;

namespace Food.Orders.Dto.Order
{
    [AutoMapFrom(typeof(Ordering.Order))]
    public class OrderDto : EntityDto<int>
    {
        public DateTime CreationTime { get; set; }
        public OrderFormDto Form { get; set; }
        public PaymentDto Payment { get; set; }
        public BasketDto Basket { get; set; }
    }
}
