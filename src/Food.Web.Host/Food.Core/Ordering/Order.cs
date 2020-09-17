using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Food.Authorization.Users;
using Food.Orders.Dto;

namespace Food.Ordering
{
    public class Order : IFullAudited<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<OrderItemsDto> Items { get; set; }

        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public User CreatorUser { get; set; }
        public User LastModifierUser { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
        public User DeleterUser { get; set; }
    }

    public class OrderItemsDto
    {
        public OrderItemType Type { get; set; }
        public int Count { get; set; }
        public DateTime StartTime { get; set; }
        public int NumberOfDays { get; set; }
        public bool IncludingWeekends { get; set; }
        //for future reference, to be able to exclude some days
        public IEnumerable<DeliveryTime> DeliveryTimes { get; set; }
    }

    public class DeliveryTime
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
    }
}
