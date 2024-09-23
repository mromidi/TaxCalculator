using TaxCalculator.Domain.Entities.Base;

namespace TaxCalculator.Domain.Entities
{
    public class TollStation : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }

        public virtual ICollection<VehicleEntry> VehicleEntries { get; set; }
    }
}
