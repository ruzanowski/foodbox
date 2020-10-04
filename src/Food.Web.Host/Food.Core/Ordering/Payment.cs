using Abp.Domain.Entities;

namespace Food.Ordering
{
    public class Payment : Entity<int>
    {
        public string TransactionId { get; set; }
        public string PaymentProvider { get; set; }
    }
}
