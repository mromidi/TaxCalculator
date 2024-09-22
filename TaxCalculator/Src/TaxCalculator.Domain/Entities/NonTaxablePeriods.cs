
namespace TaxCalculator.Domain.Entities
{
    internal class NonTaxablePeriods
    {
        public bool Weekends { get; set; }
        public List<DateOnly> PublicHolidays { get; set; }
        public bool MonthOfJuly { get; set; }
    }
}
