namespace Ngclopedia.Application.DataTransferObjects.Forum;

public class CreateUpdateCommentRequestDto
{
    public List<string>? Pictures { get; set; }
    public string Content { get; set; }
}