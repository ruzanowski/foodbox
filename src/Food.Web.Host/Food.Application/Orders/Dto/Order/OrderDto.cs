using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Food.Orders.Dto.Basket;
using Food.Orders.Dto.OrderForm;
using Food.Payments.Dto;

namespace Food.Orders.Dto.Order
{
    [AutoMapFrom(typeof(Ordering.Order))]
    public class OrderDto : EntityDto<int>
    {
        [Required]
        public DateTime CreationTime { get; set; }
        [Required]
        public OrderFormDto Form { get; set; }
        public PaymentDto Payment { get; set; }
        [Required]
        public BasketDto Basket { get; set; }
    }
}
