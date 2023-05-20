﻿using SEPAL.Analytics.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEPAL.Analytics.DAL.DatabaseManager
{
    public class OracleRepository<T> : IRepository<T>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly string tableName;

        public OracleRepository(IDatabaseContext databaseContext, string tableName)
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
            string query = GenerateInsertQuery(entity);
            databaseContext.ExecuteNonQuery(query);
        }

        public void Update(T entity)
        {
            string query = GenerateUpdateQuery(entity);
            databaseContext.ExecuteNonQuery(query);
        }

        public void Delete(T entity)
        {
            string query = GenerateDeleteQuery(entity);
            databaseContext.ExecuteNonQuery(query);
        }

        private string GenerateInsertQuery(T entity)
        {
            // Generate the INSERT query dynamically based on the properties of the entity

            var properties = typeof(T).GetProperties();
            var columns = string.Join(", ", properties.Select(p => p.Name));
            var values = string.Join(", ", properties.Select(p => $"'{p.GetValue(entity)}'"));
            var query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
            return query;

            // Note: This is just a placeholder, you need to customize it based on your entity structure and mapping logic
            // return string.Empty;
        }

        private string GenerateUpdateQuery(T entity)
        {
            // Generate the UPDATE query dynamically based on the properties of the entity
            // Example:
            var properties = typeof(T).GetProperties();
            var setValues = string.Join(", ", properties.Select(p => $"{p.Name} = '{p.GetValue(entity)}'"));
            var query = $"UPDATE {tableName} SET {setValues} WHERE ...";
            return query;

            // Note: This is just a placeholder, you need to customize it based on your entity structure and mapping logic
            // return string.Empty;
        }

        private string GenerateDeleteQuery(T entity)
        {
            //Generate the DELETE query dynamically based on the properties of the entity
            //Example:
            var properties = typeof(T).GetProperties();
            var conditions = string.Join(" AND ", properties.Select(p => $"{p.Name} = '{p.GetValue(entity)}'"));
            var query = $"DELETE FROM {tableName} WHERE {conditions}";
            return query;

            // Note: This is just a placeholder, you need to customize it based on your entity structure and mapping logic
            //return string.Empty;
        }
    }
}
