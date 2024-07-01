using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Users;

namespace Partify.WebApi.Models.AddComments;

public class AdCommentCreateModel
{
	public long? ParentId { get; set; }
	public long UserId { get; set; }
	public long AdId { get; set; }
	public string Comment { get; set; }
}