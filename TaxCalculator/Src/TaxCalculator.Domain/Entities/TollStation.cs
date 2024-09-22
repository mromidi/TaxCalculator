using TaxCalculator.Domain.Entities.Base;

namespace TaxCalculator.Domain.Entities
{
    internal class TollStation : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}
