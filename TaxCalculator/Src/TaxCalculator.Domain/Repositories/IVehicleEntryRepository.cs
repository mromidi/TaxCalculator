using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Repositories
{
    public interface IVehicleEntryRepository
    {
        Task<VehicleEntry> AddVehicleEntryAsync(VehicleEntry entity);
        Task<List<VehicleEntry>> GetVehicleEntryAsync(DateTime entryDate);
        Task<List<VehicleEntry>> GetVehicleEntryAsync(int year);
    }
}
