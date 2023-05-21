using Oracle.ManagedDataAccess.Client;
using SEPAL.Analytics.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SEPAL.Analytics.DAL.DatabaseManager
{
    internal class OracleDatabaseContext : IDatabaseContext<OracleParameter>
    {
        private readonly string connectionString;
        public OracleDatabaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<T> ExecuteQuery<T>(string query)
        {
            var result = new List<T>();

            using (var connection = new OracleConnection(connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var entity = MapToEntity<T>(reader); // Map the data from the reader to entity
                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public bool ExecuteNonQuery(string query)
        {
            bool Status = false;
            try
            {
                using (var connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                Status = true;
            }
            catch (Exception ex)
            {
                Status = false;
                throw new Exception("Exception Occurred During Insert, Update, or Delete Operation :  {0}", ex);
            }
            return Status;
        }


        private T MapToEntity<T>(OracleDataReader reader)
        {
            // Implement your mapping logic here to map the data from the reader to entity of type T
            // Example:
            // var entity = new T();
            // entity.Property1 = reader.GetString(0);
            // entity.Property2 = reader.GetInt32(1);
            // ...
            // return entity;

            // Note: This is just a placeholder, you need to customize it based on your entity mapping logic
            return default(T);
        }

        public IEnumerable<T> ExecuteProcedure<T>(string procedureName, params OracleParameter[] parameters)
        {

            var result = new List<T>();

            using (var connection = new OracleConnection(connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var entity = MapToEntity<T>(reader); // Map the data from the reader to entity
                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public IEnumerable<T> ExecuteMaterializedView<T>(string viewName, params OracleParameter[] parameters)
        {
            var query = $"SELECT * FROM {viewName}";
            return ExecuteQuery<T>(query);
        }

        public IEnumerable<T> ExecuteCTE<T>(string cteQuery, params OracleParameter[] parameters)
        {
            var query = $"WITH cte AS ({cteQuery}) SELECT * FROM cte";
            return ExecuteQuery<T>(query);
        }

        public IEnumerable<T> ExecuteView<T>(string viewName, params OracleParameter[] parameters)
        {
            var query = $"SELECT * FROM {viewName}";
            return ExecuteQuery<T>(query);
        }

        public IEnumerable<T> ExecuteForeignTable<T>(string tableName, params OracleParameter[] parameters)
        {
            var query = $"SELECT * FROM {tableName}";
            return ExecuteQuery<T>(query);
        }
    }
}
