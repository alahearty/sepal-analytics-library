using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SEPAL.Analytics.DAL.Abstractions
{

    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

}
