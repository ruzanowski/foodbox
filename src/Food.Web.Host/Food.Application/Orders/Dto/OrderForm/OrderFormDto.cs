using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Food.Orders.Dto.OrderForm
{
    [AutoMapFrom(typeof(Ordering.OrderForm))]
    public class OrderFormDto : EntityDto<long>
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
        [Required]
        public string FlatNumber { get; set; }
        [Required]
        public string GateAccessCode { get; set; }
        [Required]
        public string Remarks { get; set; }

    }
}
