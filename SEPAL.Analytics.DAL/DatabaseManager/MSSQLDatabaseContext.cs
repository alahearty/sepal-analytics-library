﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SEPAL.Analytics.DAL.Abstractions;

namespace SEPAL.Analytics.DAL.DatabaseManager
{

    public class MSSQLDatabaseContext : IDatabaseContext<SqlParameter>
    {
        private readonly string connectionString;
        public MSSQLDatabaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<T> ExecuteQuery<T>(string query)
        {
            var result = new List<T>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
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
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
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

        public IEnumerable<T> ExecuteProcedure<T>(string procedureName, params SqlParameter[] parameters)
        {
            var result = new List<T>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(procedureName, connection))
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

        public IEnumerable<T> ExecuteMaterializedView<T>(string viewName, params SqlParameter[] parameters)
        {
            var query = $"SELECT * FROM {viewName}";
            return ExecuteQuery<T>(query);
        }

        public IEnumerable<T> ExecuteCTE<T>(string cteQuery, params SqlParameter[] parameters)
        {
            var query = $"WITH cte AS ({cteQuery}) SELECT * FROM cte";
            return ExecuteQuery<T>(query);
        }

        public IEnumerable<T> ExecuteView<T>(string viewName, params SqlParameter[] parameters)
        {
            var query = $"SELECT * FROM {viewName}";
            return ExecuteQuery<T>(query);
        }

        public IEnumerable<T> ExecuteForeignTable<T>(string tableName, params SqlParameter[] parameters)
        {
            var query = $"SELECT * FROM {tableName}";
            return ExecuteQuery<T>(query);
        }

        private T MapToEntity<T>(SqlDataReader reader) 
        {
            var entity = Activator.CreateInstance<T>(); // Create an instance of the entity using reflection

            // Implement your mapping logic here to map the data from the reader to entity of type T
            // Example:
            // entity.Property1 = reader.GetString(0);
            // entity.Property2 = reader.GetInt32(1);
            // ...

            // Note: You need to ensure that the property names and data types in the reader match the properties of the entity

            return entity;
        }
    }


}
