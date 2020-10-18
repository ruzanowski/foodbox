using System;
using Abp.AutoMapper;

namespace Food.Orders.Dto.DeliveryTime
{
    [AutoMapTo(typeof(Ordering.DeliveryTime))]
    public class CreateDeliveryTimeDto
    {
        public DateTime DateTime { get; set; }
    }
}
