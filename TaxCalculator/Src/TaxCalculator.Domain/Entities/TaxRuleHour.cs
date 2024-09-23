
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TaxCalculator.Domain.Entities
{
    public class TaxRuleHour
    {      
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Amount { get; set; }
    }
}
