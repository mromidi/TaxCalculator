
namespace TaxCalculator.Domain.Entities
{
    internal class CityRulesDetail
    {
        public string City { get; set; }
        public int MaxDailyTax { get; set; }
        public List<string> ExemptVehicles { get; set; }
        public List<TaxRule> TaxRules { get; set; }
        public int SingleChargeWindow { get; set; }
        public NonTaxablePeriods NonTaxablePeriods { get; set; }
    }
}
