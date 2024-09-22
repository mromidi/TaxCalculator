using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Rules
{
    public class SingleChargeRule : ITravelRule
    {
        public bool IsApplicable(VehicleEntry entry, TaxCalculationContext context)
        {
            return context.LastTaxedTime.HasValue &&
               (entry.EntryTime - context.LastTaxedTime.Value).TotalMinutes <= 60;
        }

        public decimal CalculateTax(VehicleEntry entry, TaxCalculationContext context)
        {
            if (context.CurrentTaxAmount > context.HighestChargeInWindow)
            {
                context.HighestChargeInWindow = context.CurrentTaxAmount;
            }

            context.CurrentTaxAmount = context.HighestChargeInWindow;
            context.LastTaxedTime = entry.EntryTime;
            return context.CurrentTaxAmount;
        }


    }
}
