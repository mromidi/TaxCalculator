
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Rules
{
    public class WeekendAndHolidayRule : ITravelRule
    {
        private readonly NonTaxablePeriods _nonTaxablePeriods;

        public WeekendAndHolidayRule(NonTaxablePeriods nonTaxablePeriods)
        {
            _nonTaxablePeriods = nonTaxablePeriods;
        }

        public bool IsApplicable(VehicleEntry entry, TaxCalculationContext context)
        {
            var entryDate = entry.EntryTime.Date;

            return IsWeekend(entryDate) || IsPublicHoliday(entryDate) || IsJuly(entryDate);
        }

        public decimal CalculateTax(VehicleEntry entry, TaxCalculationContext context)
        {
            context.CurrentTaxAmount = 0;
            context.IsTaxExempt = true;
            return 0;
        }

        private bool IsWeekend(DateTime date)
        {
            return _nonTaxablePeriods.Weekends && (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
        }

        private bool IsPublicHoliday(DateTime date)
        {
            return _nonTaxablePeriods.PublicHolidays != null && _nonTaxablePeriods.PublicHolidays.Any(a => a.Date == date || a.Date.AddDays(-1) == date);
        }

        private bool IsJuly(DateTime date)
        {
            return _nonTaxablePeriods.MonthOfJuly && date.Month == 7;
        }
    }

}
