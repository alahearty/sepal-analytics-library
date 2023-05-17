using System;
using System.Collections.Generic;
using System.Text;

namespace SEPAL.Analytics.DAL.Abstractions
{
    public interface IDatabaseContext
    {
        IEnumerable<T> ExecuteQuery<T>(string query);
        void ExecuteNonQuery(string query);
    }
}
