using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Repository
{
    public class Searcher<T> : ISearcher<T> where T : class
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Searcher(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> ListBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
            }
            return await query.ToListAsync();
        }

        public async Task<T> Insert(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            try
            {
                var editedEntity = await GetBy(id);
                _context.Entry(editedEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return editedEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<T> GetBy(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            return entity;
        }

        public async Task Remove(int id)
        {
            var entity = await GetBy(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
