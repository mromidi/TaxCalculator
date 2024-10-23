using TaxCalculator.Domain.Entities.Base;
using TaxCalculator.Domain.Enums;

namespace TaxCalculator.Domain.Entities
{
    public class VehicleEntry : BaseEntity
    {
        /// <summary>
        /// The type of the vehicle (e.g., Car, Bus, Motorcycle, Emergency, Diplomat, Military, etc.).
        /// This can be used to check if the vehicle is exempt from the tax.
        /// </summary>
        public VehicleTypeEnum VehicleType { get; set; }

        /// <summary>
        /// A unique number for the vehicle, such as a registration number.
        /// </summary>
        public int VehicleNumber { get; set; }

        /// <summary>
        /// The date and time when the vehicle entered the congestion zone.
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// The toll station or zone identifier if multiple toll points exist.
        /// </summary>
        public int TollStationId { get; set; }

        /// <summary>
        /// Any additional properties for the VehicleEntry model, like entry/exit flags or comments.
        /// </summary>
        public string AdditionalInfo { get; set; }

        public virtual TollStation TollStation { get; set; }
    }
}
