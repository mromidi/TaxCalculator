using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Rules
{
    public interface ITravelRule
    {
        bool IsApplicable(VehicleEntry entry, TaxCalculationContext context);
        decimal CalculateTax(VehicleEntry entry, TaxCalculationContext context);
    }
}
