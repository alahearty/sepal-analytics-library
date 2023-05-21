using MongoDB.Driver;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using SEPAL.Analytics.DAL.Abstractions;
using SEPAL.Analytics.DAL.DataRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SEPAL.Analytics.DAL.DatabaseManager
{
    public class DataAccessFactory
    {
        public static IRepository<T> CreateRepository<T, TContext, TParameter>(string databaseType, TContext databaseContext, string tableName)
            where TContext : IDatabaseContext<TParameter>
            where TParameter : IDbDataParameter
        {
            switch (databaseType)
            {
                case "PostgreSQL":
                    if (databaseContext is IDatabaseContext<NpgsqlParameter> postgresContext)
                    {
                        return new PostgreSQLRepository<T, IDatabaseContext<NpgsqlParameter>>(postgresContext, tableName);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid database context for PostgreSQL repository.");
                    }
                case "MSSQLServer":
                    if (databaseContext is IDatabaseContext<SqlParameter> mssqlContext)
                    {
                        return new MSSQLRepository<T, IDatabaseContext<SqlParameter>>(mssqlContext, tableName);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid database context for MSSQLServer repository.");
                    }
                case "Oracle":
                    if (databaseContext is IDatabaseContext<OracleParameter> oracleContext)
                    {
                        return new OracleRepository<T, IDatabaseContext<OracleParameter>>(oracleContext, tableName);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid database context for Oracle repository.");
                    }
                case "MongoDB":
                    if (databaseContext is IMongoDatabase mongoDatabase)
                    {
                        var mongoCollection = mongoDatabase.GetCollection<T>(tableName);
                        if (mongoCollection == null)
                        {
                            throw new InvalidOperationException($"Collection '{tableName}' does not exist in the MongoDB database.");
                        }
                        return new MongoDbRepository<T>(mongoCollection);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid database context for MongoDB repository.");
                    }
                default:
                    throw new NotSupportedException("Database type not supported.");
            }
        }
    }


}