using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.DTO.Stock;
using web_api.Interface;
using web_api.Mapper;

namespace web_api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepo;
        public StockController(IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stock = await _stockRepo.GetAllAsync();
            var stockDTO = stock.Select(u => u.ToStockDTO());
            return Ok(stockDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var stock = await _stockRepo.GetAsync(u => u.Id == id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StockRequestCreateDTO stock)
        {
            var stockModel = stock.ToStockCreateDTO();
            await _stockRepo.CreateAsync(stockModel);
            await _stockRepo.Save();
            return CreatedAtAction(nameof(Get), new { id = stockModel.Id }, stockModel.ToStockDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StockRequestUpdateDTO stock)
        {
            var stockModel = await _stockRepo.UpdateAsync(u => u.Id == id, stock);
            if (stockModel == null)
            {
                return NotFound();
            }
            await _stockRepo.Save();
            return Ok(stockModel.ToStockDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _stockRepo.RemoveAsync(u => u.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            await _stockRepo.Save();
            return NoContent();
        }
    }
}