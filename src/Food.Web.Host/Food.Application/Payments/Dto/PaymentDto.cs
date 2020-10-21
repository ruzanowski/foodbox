using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Food.Ordering;

namespace Food.Payments.Dto
{
    [AutoMapFrom(typeof(Payment))]
    public class PaymentDto : EntityDto<int>
    {
        [Required]
        public string TransactionId { get; set; }
        [Required]
        public string PaymentProvider { get; set; }
        [Required]
        [Range(0,1000000)]
        public decimal ValuePaid { get; set; }
        [Required]
        [Range(0,1000000)]
        public decimal ValueGrossPaid { get; set; }
        [Required]
        [Range(0,1000000)]
        public decimal TaxPaid { get; set; }
    }
}
