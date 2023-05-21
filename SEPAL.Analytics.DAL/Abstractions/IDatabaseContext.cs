using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SEPAL.Analytics.DAL.Abstractions
{
    public interface IDatabaseContext
    {
        IEnumerable<T> ExecuteQuery<T>(string query);
        bool ExecuteNonQuery(string query);
        IEnumerable<T> ExecuteProcedure<T>(string procedureName, params SqlParameter[] parameters);
        IEnumerable<T> ExecuteMaterializedView<T>(string viewName, params SqlParameter[] parameters);
        IEnumerable<T> ExecuteCTE<T>(string cteQuery, params SqlParameter[] parameters);
        IEnumerable<T> ExecuteView<T>(string viewName, params SqlParameter[] parameters);
        IEnumerable<T> ExecuteForeignTable<T>(string tableName, params SqlParameter[] parameters);
    }


}
