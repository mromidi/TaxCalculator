using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Repositories
{
    internal interface IVehicleEntryRepository
    {
        Task<VehicleEntry> AddVehicleEntryAsync(VehicleEntry entity);
        Task<List<VehicleEntry>> GetVehicleEntryAsync(DateTime entryDate);
    }
}
