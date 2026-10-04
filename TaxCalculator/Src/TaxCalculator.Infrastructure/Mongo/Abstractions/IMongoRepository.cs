using MongoDB.Driver;
using System.Linq.Expressions;

namespace TaxCalculator.Infrastructure.Mongo.Abstractions
{
    public interface IMongoRepository<T> where T : class
    {
        void SetCollection(IMongoCollection<T> collection);
        Task<IList<T>> GetAllAsync(FilterDefinition<T> filter);
        Task<T> FindOneAsync(Expression<Func<T, bool>> filter);
        Task<T> FindOneAsync(FilterDefinition<T> filter);
        Task CreateAsync(T item);
        Task<T> SingleByIdAsync(string id);
    }
}
