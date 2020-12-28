using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HR.BLL.Services
{
    public interface IGenericService<T, TKey> where T : class, new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(TKey id);
        T Add(T obj);
        T Update(T obj);
        //T Delete(T obj);
        T Delete(TKey id);
    }
}
