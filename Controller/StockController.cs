using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace api;
[Route("api/stock")]
[ApiController]
public class StockController:ControllerBase
{
    [HttpGet]
    public IActionResult GetAll(){
        var stocks=new List<string>{
           "ok","too bad ","hmm"
        };
        return Ok(stocks);
    }
}
