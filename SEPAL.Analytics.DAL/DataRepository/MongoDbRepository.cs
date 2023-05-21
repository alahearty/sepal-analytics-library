using MongoDB.Driver;
using SEPAL.Analytics.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEPAL.Analytics.DAL.DataRepository
{
    public class MongoDbRepository<T> : IRepository<T>
    {
        private readonly IMongoCollection<T> collection;

        public MongoDbRepository(IMongoCollection<T> collection)
        {
            this.collection = collection;
        }

        public IEnumerable<T> GetAll()
        {
            return collection.Find(FilterDefinition<T>.Empty).ToList();
        }

        public void Add(T entity)
        {
            collection.InsertOne(entity);
        }

        public void Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetEntityId(entity));
            collection.ReplaceOne(filter, entity);
        }

        public void Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetEntityId(entity));
            collection.DeleteOne(filter);
        }

        private object GetEntityId(T entity)
        {
            var idProperty = typeof(T).GetProperty("_id");
            if (idProperty != null)
            {
                return idProperty.GetValue(entity);
            }
            else
            {
                throw new NotSupportedException("Entity doesn't have an '_id' property.");
            }
        }
    }
}
