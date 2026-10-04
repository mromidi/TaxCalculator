using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Application.Dtos
{
    public class DateGroup
    {
        public DateTime Date { get; set; }
        public IEnumerable< IGrouping<int, VehicleEntry>> Vehicles { get; set; }
    }
}
