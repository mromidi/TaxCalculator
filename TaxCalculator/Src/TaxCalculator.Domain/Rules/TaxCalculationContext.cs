
namespace TaxCalculator.Domain.Rules
{
    public class TaxCalculationContext
    {

        public decimal CurrentTaxAmount { get; set; } = 0;
        public List<EntryPaidInfo> PaidInfo { get; set; } = new();
        public bool IsTaxExempt { get; set; } = false;
    }
}
