using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Repositories
{
    public interface ICityRulesDetailRepository
    {
        Task<CityRulesDetail> GetActiveCityRulesDetail(int year, string city);
    }
}
