namespace api;

public class CreateCommentDto
{
    // data validation annotation for Dtos and not for models
    [required]
    [minLength(5,ErrorMessage="minlength is 5")]
    public string Title { get; set; }=string.Empty;
    [required]
    [minLength(5,ErrorMessage="minlength is 5")]
    public string Content { get; set; }=string.Empty;
}
