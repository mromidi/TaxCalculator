
namespace TaxCalculator.Domain.Rules
{
    public class TaxCalculationContext
    {
        public decimal CurrentTaxAmount { get; set; } = 0;
        public DateTime? LastTaxedTime { get; set; } = null;
        public bool IsTaxExempt { get; set; } = false; 
        public decimal HighestChargeInWindow { get; set; } = 0;
    }
}
