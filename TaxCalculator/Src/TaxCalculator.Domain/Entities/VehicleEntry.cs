
using TaxCalculator.Domain.Enums;

namespace TaxCalculator.Domain.Entities
{
    internal class VehicleEntry
    {
        /// <summary>
        /// A unique identifier for the vehicle, such as a registration number or VIN.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The type of the vehicle (e.g., Car, Bus, Motorcycle, Emergency, Diplomat, Military, etc.).
        /// This can be used to check if the vehicle is exempt from the tax.
        /// </summary>
        public VehicleTypeEnum VehicleType { get; set; }

        public int VehicleNumber { get; set; }

        /// <summary>
        /// The date and time when the vehicle entered the congestion zone.
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// The tax amount calculated for this entry. This will be filled in by the rule engine.
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// The toll station or zone identifier if multiple toll points exist.
        /// </summary>
        public int TollStationId { get; set; }

        /// <summary>
        /// Any additional properties for the VehicleEntry model, like entry/exit flags or comments.
        /// </summary>
        public string AdditionalInfo { get; set; }
    }
}
