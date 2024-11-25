using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using web_api.Model;

namespace web_api.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task<T?> RemoveAsync(Expression<Func<T, bool>> expression);
        Task Save();
    }
}