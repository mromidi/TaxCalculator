using Microsoft.EntityFrameworkCore;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Domain.Repositories;
using TaxCalculator.Infrastructure.EF.Contexts;

namespace TaxCalculator.Infrastructure.EF.Repositories
{
    public class VehicleEntryRepository : IVehicleEntryRepository
    {
        private readonly TaxDbContext _taxDbContext;

        public VehicleEntryRepository(TaxDbContext taxDbContext)
        {
            _taxDbContext = taxDbContext;
        }

        public async Task<VehicleEntry> AddVehicleEntryAsync(VehicleEntry entity)
        {
            var result = await _taxDbContext.Set<VehicleEntry>().AddAsync(entity);
            await _taxDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<VehicleEntry>> GetVehicleEntryAsync(DateTime entryDate)
        {
            return await _taxDbContext.Set<VehicleEntry>().Where(w => w.EntryTime.Date == entryDate.Date).ToListAsync();
        }

        public async Task<List<VehicleEntry>> GetVehicleEntryAsync(int year)
        {
            return await _taxDbContext.Set<VehicleEntry>().Include(i=>i.TollStation).ToListAsync();
        }
    }
}
