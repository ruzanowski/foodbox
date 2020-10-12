using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace Food.Orders.Dto.OrderForm
{
    [AutoMapTo(typeof(Ordering.OrderForm))]
    public class CreateOrderFormDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string GateAccessCode { get; set; }
        public string Remarks { get; set; }
    }
}
