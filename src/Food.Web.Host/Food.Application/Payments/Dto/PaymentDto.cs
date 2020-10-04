using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Food.Ordering;

namespace Food.Payments.Dto
{
    [AutoMapFrom(typeof(Payment))]
    public class PaymentDto : EntityDto<int>
    {
        public string TransactionId { get; set; }
        public string PaymentProvider { get; set; }
    }
}
