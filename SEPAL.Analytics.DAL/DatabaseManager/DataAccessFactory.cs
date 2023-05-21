using MongoDB.Driver;
using SEPAL.Analytics.DAL.Abstractions;
using SEPAL.Analytics.DAL.DataRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEPAL.Analytics.DAL.DatabaseManager
{
    public class DataAccessFactory
    {
        public static IRepository<T> CreateRepository<T>(string databaseType, IDatabaseContext databaseContext, string tableName)
        {
            switch (databaseType)
            {
                case "PostgreSQL":
                    return new PostgreSQLRepository<T>(databaseContext, tableName);
                case "MSSQLServer":
                    return new MSSQLRepository<T>(databaseContext, tableName);
                case "Oracle":
                    return new OracleRepository<T>(databaseContext, tableName);
                case "MongoDB":
                    var mongoDatabase = (databaseContext as IMongoDatabase);
                    var mongoCollection = mongoDatabase?.GetCollection<T>(tableName);
                    if (mongoCollection == null)
                    {
                        throw new InvalidOperationException($"Collection '{tableName}' does not exist in the MongoDB database.");
                    }
                    return new MongoDbRepository<T>(mongoCollection);
                default:
                    throw new NotSupportedException("Database type not supported.");
            }
        }
    }

}
