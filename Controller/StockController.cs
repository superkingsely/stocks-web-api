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
    private readonly IStockRepo _stockrepo;
    private readonly ApplicationDb _context;
    public StockController(ApplicationDb context,IStockRepo stockrepo)
    {
        _stockrepo=stockrepo;
        _context=context;
    }
    // Read all data
    [HttpGet]
    public async Task< IActionResult> GetAll(){
        var stocks=await _stockrepo.GetAllAsync();
        var stocksDto=stocks.Select(obj=>obj.ToStockDto());

        return Ok(stocksDto);
    }
    [HttpGet("{id:int}")]
    public async Task< IActionResult> GetById([FromRoute] int id){
        var stock=await _stockrepo.GetByIdAsync(id);
        if (stock==null)
        {
            return NotFound();
        }
        return Ok(stock.ToStockDto());
    }
    // Create
    [HttpPost]
    public async Task< IActionResult> Creat([FromBody] CreateStockRequestDto stockDto){
         if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var stockModel=stockDto.ToStockFromCreateDto();
        await _stockrepo.CreateAsync(stockModel);
        return CreatedAtAction(nameof(GetById),new {id=stockModel.Id},stockModel.ToStockDto());
    }
    // Update
    [HttpPut]
    [Route("{id:int}")]
    public async Task< IActionResult> Update([FromRoute] int id,[FromBody] UpdateStockRequestDto updateDto){
         if(!ModelState.IsValid)
            return BadRequest(ModelState);
            var stockModel=await _stockrepo.UpdateAsync(id,updateDto);
             if(stockModel==null){
            return NotFound();
        }
           return Ok(stockModel.ToStockDto());
    }
    // Delete
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id){
        var stockModel=await _stockrepo.DeleteAsync(id);
        if(stockModel==null){
            return NotFound();
        }
        // use the entity to remove
         _context.stocks.Remove(stockModel);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
