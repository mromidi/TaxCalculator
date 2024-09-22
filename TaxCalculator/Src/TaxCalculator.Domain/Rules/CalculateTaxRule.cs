using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Rules
{
    public class CalculateTaxRule : ITravelRule
    {
        private readonly List<TaxRuleHour> _activeCityTaxRulesHours;
        public CalculateTaxRule(List<TaxRuleHour> activeCityTaxRules)
        {
            _activeCityTaxRulesHours = activeCityTaxRules;
        }
 
        public bool IsApplicable(VehicleEntry entry, TaxCalculationContext context)
        {
            return true;
        }

        public decimal CalculateTax(VehicleEntry entry, TaxCalculationContext context)
        {
            var taxRule = _activeCityTaxRulesHours
                .Where(w => entry.EntryTime.TimeOfDay >= w.StartTime.ToTimeSpan()
                            && entry.EntryTime.TimeOfDay <= w.EndTime.ToTimeSpan())
                .OrderByDescending(o => o.Amount)
                .FirstOrDefault();


            if (taxRule is null)
            {
                return 0;
            }

            context.CurrentTaxAmount = taxRule.Amount;
            return taxRule.Amount;
        }
    }
}
