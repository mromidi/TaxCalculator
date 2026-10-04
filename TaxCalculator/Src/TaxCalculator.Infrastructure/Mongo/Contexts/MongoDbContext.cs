using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Infrastructure.Mongo.Abstractions;

namespace TaxCalculator.Infrastructure.Mongo.Contexts
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _configuration;
        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("Mongo:ConnectionString").Value);
            _database = client.GetDatabase(configuration.GetSection("Mongo:PamaDatabase").Value);
            _configuration = configuration;
        }

        public IMongoCollection<CityRulesDetail> CityRulesDetail => _database.GetCollection<CityRulesDetail>("CityRulesDetails");
    }
}
