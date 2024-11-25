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
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        private readonly ApplicationDbContext _db;
        public StockRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Stock?> UpdateAsync(Expression<Func<Stock, bool>> expression, StockRequestUpdateDTO stock)
        {
            var stockModel = await _db.Stocks.FirstOrDefaultAsync(expression);
            if (stockModel == null)
            {
                return null;
            }
            stockModel.Symbol = stock.Symbol;
            stockModel.CompanyName = stock.CompanyName;
            stockModel.Purchase = stock.Purchase;
            stockModel.Industry = stock.Industry;
            stockModel.LastDiv = stock.LastDiv;
            stockModel.MarketCap = stock.MarketCap;
            return stockModel;
        }
    }
}