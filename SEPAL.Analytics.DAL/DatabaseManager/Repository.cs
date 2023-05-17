using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SEPAL.Analytics.DAL.Abstractions;

namespace SEPAL.Analytics.DAL.DatabaseManager
{
    public class Repository<T> : IRepository<T>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly string tableName;

        public Repository(IDatabaseContext databaseContext, string tableName)
        {
            this.databaseContext = databaseContext;
            this.tableName = tableName;
        }

        public IEnumerable<T> GetAll()
        {
            string query = $"SELECT * FROM {tableName}";
            return databaseContext.ExecuteQuery<T>(query);
        }

        public void Add(T entity)
        {
            // Implement logic to insert the entity into the database
        }

        public void Update(T entity)
        {
            // Implement logic to update the entity in the database
        }

        public void Delete(T entity)
        {
            // Implement logic to delete the entity from the database
        }
    }

}
