using System;
using Abp.Domain.Entities;

namespace Food.Ordering
{
    public class DeliveryTime : Entity<long>
    {
        public DateTime? PreferableTimeDelivery { get; set; }
        public DateTime DateTime { get; set; }
    }
}
