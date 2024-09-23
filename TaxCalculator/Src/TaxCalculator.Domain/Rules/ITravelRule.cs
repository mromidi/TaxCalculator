using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Rules
{
    public interface ITravelRule
    {
        bool IsApplicable(VehicleEntry entry, TaxCalculationContext context);
        void CalculateTax(VehicleEntry entry, TaxCalculationContext context);
    }
}
