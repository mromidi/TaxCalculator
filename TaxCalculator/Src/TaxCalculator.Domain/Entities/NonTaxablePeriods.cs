
namespace TaxCalculator.Domain.Entities
{
    public class NonTaxablePeriods
    {
        public bool Weekends { get; set; }
        public List<DateTime> PublicHolidays { get; set; }
        public bool MonthOfJuly { get; set; }
    }
}
