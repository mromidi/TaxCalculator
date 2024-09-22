
namespace TaxCalculator.Domain.Entities
{
    internal class TaxRule
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int Amount { get; set; }
    }
}
