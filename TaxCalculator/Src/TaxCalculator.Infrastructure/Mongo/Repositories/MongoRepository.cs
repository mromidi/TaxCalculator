using MongoDB.Driver;
using System.Linq.Expressions;
using TaxCalculator.Infrastructure.Mongo.Abstractions;

namespace TaxCalculator.Infrastructure.Mongo.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private IMongoCollection<T> Collection { get; set; }

        public void SetCollection(IMongoCollection<T> collection)
        {
            Collection = collection;
        }
        public async Task CreateAsync(T item)
        {
            await Collection.InsertOneAsync(item, new InsertOneOptions
            {
               
                BypassDocumentValidation = false
            });

            
        }
        public async Task<T> SingleByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await Collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> filter)
        {
            return await Collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<T> FindOneAsync(FilterDefinition<T> filter)
        {
            return await Collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IList<T>> GetAllAsync(FilterDefinition<T> filter)
        {
            using (IAsyncCursor<T> cursor = await Collection.FindAsync(filter))
            {
                return await cursor.ToListAsync();
            }
        }

       
    }
}
