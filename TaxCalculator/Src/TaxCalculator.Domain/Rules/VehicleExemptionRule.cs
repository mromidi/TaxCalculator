using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Rules
{
    public class VehicleExemptionRule : ITravelRule
    {
        private readonly List<string> _exemptVehicleTypes;

        public VehicleExemptionRule(List<string> exemptVehicleTypes)
        {
            _exemptVehicleTypes = exemptVehicleTypes;
        }

        public bool IsApplicable(VehicleEntry entry, TaxCalculationContext context)
        {
            return _exemptVehicleTypes.Contains(entry.VehicleType.ToString());
        }

        public void CalculateTax(VehicleEntry entry, TaxCalculationContext context)
        {
            Console.WriteLine($"VehicleExemptionRule is fired");
            context.CurrentTaxAmount = 0;
            context.IsTaxExempt = true;
        }


    }
}
