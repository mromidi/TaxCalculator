
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Rules
{
    public class RuleEngine
    {
        private readonly IEnumerable<ITravelRule> _travelRules;
        public RuleEngine(IEnumerable<ITravelRule> travelRules)
        {
            _travelRules = travelRules;
        }

        public decimal CalculateTaxAmount(VehicleEntry vehicleEntry)
        {
            var context = new TaxCalculationContext();

            foreach (var rule in _travelRules)
            {
                if (rule.IsApplicable(vehicleEntry, context))
                {
                    rule.CalculateTax(vehicleEntry, context);
                    if (context.IsTaxExempt)
                    {
                        context.CurrentTaxAmount = 0;
                        break;
                    }
                }

            }
            return context.CurrentTaxAmount;
        }


    }
}
