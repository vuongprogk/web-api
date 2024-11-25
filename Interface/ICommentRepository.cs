using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using web_api.Model;

namespace web_api.Interface
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<Comment?> UpdateAsync(Expression<Func<Comment, bool>> expression, Object test);
    }
}