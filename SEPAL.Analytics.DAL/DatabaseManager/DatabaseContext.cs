using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SEPAL.Analytics.DAL.Abstractions;

namespace SEPAL.Analytics.DAL.DatabaseManager
{

    public class DatabaseContext : IDatabaseContext
    {
        private readonly string connectionString;

        public DatabaseContext(string connectionString)
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
                            // Map the data to the appropriate entity type T
                            //var entity = // Map the data from the reader to entity
                            //result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public void ExecuteNonQuery(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
