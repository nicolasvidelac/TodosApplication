using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TodoList.Repository
{
    public interface ISearcher<T> where T : class
    {
        public Task<IEnumerable<T>> ListBy(Expression<Func<T, bool>> predicate);
        public  Task<T> Insert(T entity);
        public  Task<T> Update(int id, T entity);
        public Task<T> GetById(int id);
        public Task<T> GetBy(Expression<Func<T, bool>> predicate);
        public Task Remove(int id);
     }
}

