using Abp.Domain.Entities;

namespace Food.Ordering
{
    public class Payment : Entity<int>
    {
        public string TransactionId { get; set; }
        public string PaymentProvider { get; set; }
        public decimal ValuePaid { get; set; }
        public decimal ValueGrossPaid { get; set; }
        public decimal TaxPaid { get; set; }
    }
}
