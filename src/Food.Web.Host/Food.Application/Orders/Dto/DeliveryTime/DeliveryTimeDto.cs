using System;
using Abp.AutoMapper;

namespace Food.Orders.Dto.DeliveryTime
{
    [AutoMapFrom(typeof(Ordering.DeliveryTime))]
    public class DeliveryTimeDto
    {
        public DateTime? PreferableTimeDelivery { get; set; }
        public DateTime DateTime { get; set; }
    }
}
