using MongoDB.Driver;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Infrastructure.Mongo.Abstractions
{
    public interface IMongoDbContext
    {
        IMongoCollection<CityRulesDetail> CityRulesDetail { get; }
    }
}
