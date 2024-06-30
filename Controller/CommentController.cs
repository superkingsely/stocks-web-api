using Microsoft.AspNetCore.Mvc;

namespace api;
[Route("api/comment")]
[ApiController]
public class CommentController:ControllerBase
{
    private readonly ICommentRepo _commentRepo;
    private readonly IStockRepo _stockRepo;

    public CommentController(ICommentRepo commentRepo,IStockRepo stockRepo)
    {
     _commentRepo=commentRepo;   
     _stockRepo=stockRepo;
    }

    // read all
    [HttpGet]
    public async Task<IActionResult> GetAll(){
        var comments=await _commentRepo.GetAllAsync();
        var commentDtos=comments.Select(obj=>obj.ToCommentDto());
        return Ok(commentDtos);
    }

    [HttpGet]
    //route constraint int
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id){
        var comment=await _commentRepo.GetByIdAsync(id);
        if(comment==null){
            return NotFound();
        }
        return Ok(comment.ToCommentDto());
    }
    [HttpPost("{stockId:int}")]
    public async Task<IActionResult> Create([FromRoute] int stockId,CreateCommentDto commentDto){
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        if(!await _stockRepo.StockExist(stockId)){
            return BadRequest("Stock nodey");
        }
        var commentModel=commentDto.ToCommentFromCreate(stockId);
        await _commentRepo.CreateAsync(commentModel);
        return CreatedAtAction(nameof(GetById),new {id=commentModel.Id},commentModel.ToCommentDto());
    }
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommentRequestDto updateDto){
         if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var comment=await _commentRepo.UpdateAsync(id,updateDto.ToCommentFromUpdate());
        if(comment==null){
            return NotFound("comment Not found");
        }
        return Ok(comment.ToCommentDto());
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id){
        var commentModel=await _commentRepo.DeleteAsync(id);
        if(commentModel==null){
            return NotFound("comment doesnot exist");
        }
        return NoContent();
    }
}
