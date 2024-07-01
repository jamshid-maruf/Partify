namespace Partify.WebApi.Models.AddComments;

public class AdCommentUpdateModel
{
	public long? ParentId { get; set; }
	public long UserId { get; set; }
	public long AdId { get; set; }
	public string Comment { get; set; }
}
