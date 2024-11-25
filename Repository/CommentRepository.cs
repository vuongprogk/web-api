using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.DTO.Stock;
using web_api.Interface;
using web_api.Model;

namespace web_api.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _db;
        public CommentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Task<Comment?> UpdateAsync(Expression<Func<Comment, bool>> expression, object test)
        {
            throw new NotImplementedException();
        }
    }
}