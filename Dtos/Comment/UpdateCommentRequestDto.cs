namespace api;

public class UpdateCommentRequestDto
{   [required]
    [minLength(5,ErrorMessage="minlength is 5")]
    public string Title { get; set; }=string.Empty;
    [required]
    [minLength(5,ErrorMessage="minlength is 5")]
    public string Content { get; set; }=string.Empty;
}
