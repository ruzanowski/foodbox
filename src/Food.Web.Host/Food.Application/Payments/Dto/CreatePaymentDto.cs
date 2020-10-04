using Abp.AutoMapper;
using Food.Ordering;

namespace Food.Payments.Dto
{
    [AutoMapTo(typeof(Payment))]
    public class CreatePaymentDto
    {
        public string TransactionId { get; set; }
        public string PaymentProvider { get; set; }
    }
}
