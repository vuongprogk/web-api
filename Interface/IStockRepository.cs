using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using web_api.DTO.Stock;
using web_api.Model;

namespace web_api.Interface
{
    public interface IStockRepository : IRepository<Stock>
    {
        Task<Stock?> UpdateAsync(Expression<Func<Stock, bool>> expression, StockRequestUpdateDTO stock);
    }
}