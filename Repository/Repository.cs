using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Interface;

namespace web_api.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var list = await dbSet.ToListAsync();
            return list;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            var obj = await dbSet.FirstOrDefaultAsync(expression);
            return obj;
        }

        public async Task<T?> RemoveAsync(Expression<Func<T, bool>> expression)
        {
            var obj = await dbSet.FirstOrDefaultAsync(expression);
            if (obj != null)
            {
                dbSet.Remove(obj);
                return obj;
            }
            return null;
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}