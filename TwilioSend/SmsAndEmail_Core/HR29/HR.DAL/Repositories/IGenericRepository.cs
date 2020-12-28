using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HR.DAL.Repositories
{
    public interface IGenericRepository<T, TKey> where T : class, new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(TKey id);
        void Add(T obj);
        void Update(T obj);
        void Delete(TKey id);
    }
}
