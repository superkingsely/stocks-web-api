using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace api;
[Route("api/stock")]
[ApiController]
public class StockController:ControllerBase
{
    private readonly ApplicationDb _context;
    public StockController(ApplicationDb context)
    {
        _context=context;
    }
    // Read all data
    [HttpGet]
    public async Task< IActionResult> GetAll(){
        var stocks=await _context.stocks.ToListAsync();
        var stocksDto=stocks.Select(obj=>obj.ToStockDto());

        return Ok(stocksDto);
    }
    [HttpGet("{id}")]
    public async Task< IActionResult> GetById([FromRoute] int id){
        var stock=await _context.stocks.FindAsync(id);
        if (stock==null)
        {
            return NotFound();
        }
        return Ok(stock.ToStockDto());
    }
    // Create
    [HttpPost]
    public async Task< IActionResult> Creat([FromBody] CreateStockRequestDto stockDto){
        var stockModel=stockDto.ToStockFromCreateDto();
        await _context.stocks.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById),new {id=stockModel.Id},stockModel.ToStockDto());
    }
    // Update
    [HttpPut]
    [Route("{id}")]
    public async Task< IActionResult> Update([FromRoute] int id,[FromBody] UpdateStockRequestDto updateDto){
        var stockModel=await _context.stocks.FirstOrDefaultAsync(obj=>obj.Id==id);
        if(stockModel==null){
            return NotFound();
        }
           stockModel.Symbol=updateDto.Symbol;
           stockModel.CompanyName=updateDto.CompanyName;
           stockModel.Purchase=updateDto.Purchase;
           stockModel.LastDiv=updateDto.LastDiv;
           stockModel.Industry=updateDto.Industry;
           stockModel.MarketCap=updateDto.MarketCap;

          await _context.SaveChangesAsync();
           return Ok(stockModel.ToStockDto());
    }
    // Delete
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id){
        var stockModel=await _context.stocks.FirstOrDefaultAsync(obj=>obj.Id==id);
        if(stockModel==null){
            return NotFound();
        }
        // use the entity to remove
         _context.stocks.Remove(stockModel);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
