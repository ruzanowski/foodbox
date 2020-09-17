using System.Collections.Generic;
using Abp.AutoMapper;
using Food.Authorization.Users;
using Food.Ordering;

namespace Food.Orders.Dto
{
    public class OrderDto
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
    }

    [AutoMapTo(typeof(Order))]
    public class CreateOrderDto
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
    }
}
