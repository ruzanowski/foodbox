using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Food.Ordering;

namespace Food.Payments.Dto
{
    [AutoMapTo(typeof(Payment))]
    public class CreatePaymentDto
    {
        public string TransactionId { get; set; }
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
