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

        public void CalculateTax(VehicleEntry entry, TaxCalculationContext context)
        {
            Console.WriteLine($"CalculateTaxRule is fired");
            var taxRule = _activeCityTaxRulesHours
                .Where(w => entry.EntryTime.TimeOfDay >= w.StartTime.ToTimeSpan()
                            && entry.EntryTime.TimeOfDay <= w.EndTime.ToTimeSpan())
                .OrderByDescending(o => o.Amount)
                .FirstOrDefault();
            if (taxRule is null) return;


            context.CurrentTaxAmount = taxRule.Amount;
            context.PaidInfo.Add(new EntryPaidInfo { EntryTime = entry.EntryTime, Amount = taxRule.Amount, IsPaid = true });

        }

        private void AddPaidInfo(TaxCalculationContext context, DateTime entryTime, decimal amount)
        {
            context.PaidInfo.Add(new EntryPaidInfo
            {
                EntryTime = entryTime,
                Amount = amount,
                IsPaid = true
            });
        }
    }
}
