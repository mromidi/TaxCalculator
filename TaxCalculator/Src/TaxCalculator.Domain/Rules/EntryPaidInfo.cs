
namespace TaxCalculator.Domain.Rules
{
    public class EntryPaidInfo
    {
        public DateTime EntryTime { get; set; }
        public bool IsPaid { get; set; }
        public decimal Amount { get; set; }
        public bool IsLastPaid { get; set; }
    }
}
