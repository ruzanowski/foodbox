using Abp.AutoMapper;

namespace Food.Orders.Dto.OrderForm
{
    [AutoMapTo(typeof(Ordering.OrderForm))]
    public class CreateOrderFormDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string GateAccessCode { get; set; }
        public string Remarks { get; set; }
    }
}
