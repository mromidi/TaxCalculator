using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using TaxCalculator.Domain.Repositories;
using TaxCalculator.Infrastructure.EF.Contexts;
using TaxCalculator.Infrastructure.EF.Repositories;
using TaxCalculator.Infrastructure.Mongo.Abstractions;
using TaxCalculator.Infrastructure.Mongo.Contexts;
using TaxCalculator.Infrastructure.Mongo.Models;
using TaxCalculator.Infrastructure.Mongo.Repositories;

namespace TaxCalculator.Infrastructure.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<TaxDbContext>();
            services.AddScoped<IVehicleEntryRepository, VehicleEntryRepository>();
            services.AddScoped<ICityRulesDetailRepository, CityRulesDetailRepository>();
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
           
            BsonSerializer.RegisterSerializer(new TimeOnlyBsonSerializer());

        }
    }
}
