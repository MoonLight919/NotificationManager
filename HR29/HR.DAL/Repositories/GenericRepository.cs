using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace HR.DAL.Repositories
{
    public abstract class GenericRepository<T, TKey> : IGenericRepository<T,  TKey> where T : class, new() 
        where TKey : struct
    {
        DbContext context;
        DbSet<T> dbSet;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public void Add(T obj)
        {
            dbSet.Add(obj);
            context.SaveChanges();
        }

        public void Delete(TKey id)
        {
            T obj = Get(id);
            dbSet.Remove(obj);
            context.SaveChanges();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);//не работает Where
        }

        public T Get(TKey id)
        {
            return dbSet.Find(id);
        }

      

        public void Update(T obj)
        {
            dbSet.Update(obj);
            context.SaveChanges();
        }

        
    }

}
