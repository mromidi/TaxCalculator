
namespace TaxCalculator.Domain.Entities
{
    public class CityRulesDetail
    {

        public bool Active { get; set; }
        public int Year { get; set; }
        public string City { get; set; }
        public decimal MaxDailyTax { get; set; }
        public List<string> ExemptVehicles { get; set; }
        public List<TaxRuleHour> TaxRules { get; set; }
        public int SingleChargeWindow { get; set; }
        public NonTaxablePeriods NonTaxablePeriods { get; set; }
    }
}
