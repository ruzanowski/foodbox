using System;
using System.Collections.Generic;

namespace Food.Orders.Dto
{
    public class OrderItemsDto
    {
        public OrderItemType Type { get; set; }
        public int Count { get; set; }
        public DateTime StartTime { get; set; }
        public int NumberOfDays { get; set; }
        public bool IncludingWeekends { get; set; }
        //for future reference, to be able to exclude some days
        public IEnumerable<DateTime> DeliveryTimes { get; set; }
    }
}
