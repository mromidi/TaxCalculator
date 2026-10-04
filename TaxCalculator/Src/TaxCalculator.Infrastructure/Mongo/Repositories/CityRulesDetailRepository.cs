using MongoDB.Driver;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Domain.Repositories;
using TaxCalculator.Infrastructure.Mongo.Abstractions;

namespace TaxCalculator.Infrastructure.Mongo.Repositories
{
    public class CityRulesDetailRepository : ICityRulesDetailRepository
    {
        private readonly IMongoRepository<CityRulesDetail> _cityRulesRepository;

        public CityRulesDetailRepository(IMongoRepository<CityRulesDetail> cityRulesRepository, IMongoDbContext mongoDbContext)
        {
            _cityRulesRepository = cityRulesRepository;
            _cityRulesRepository.SetCollection(mongoDbContext.CityRulesDetail);
        }

        public async Task<CityRulesDetail> GetActiveCityRulesDetail(int year, string city)
        {
            var cityRules = await _cityRulesRepository.FindOneAsync(f => f.Active == true && f.City == city && f.Year == year);
            return cityRules;
        }
    }
}
