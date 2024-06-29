namespace api;

public static class CommentMapper
{
    // converting model to Dto
    public static CommentDto ToCommentDto(this Comment commentModel){
      return  new CommentDto{
            Id=commentModel.Id,
            Title=commentModel.Title,
            Content=commentModel.Content,
            CreatedOn=commentModel.CreatedOn,
            StockId=commentModel.StockId,
        };
    }
    // converting dto to model dat nw goes back to the database
    public static Comment ToCommentFromCreate(this CreateCommentDto commentDto,int stockId){
      return  new Comment{
            Title=commentDto.Title,
            Content=commentDto.Content,
            StockId=stockId,
        };
    }
    public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto){
      return  new Comment{
            Title=commentDto.Title,
            Content=commentDto.Content,
        };
    }
}
