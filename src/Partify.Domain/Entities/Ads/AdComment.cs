using Partify.Domain.Commons;
using Partify.Domain.Entities.Users;

namespace Partify.Domain.Entities.Ads;

public class AdComment : Auditable
{
	public long? ParentId { get; set; }
	public long UserId { get; set; }
	public User User { get; set; }
	public long AdId { get; set; }
	public Ad Ad { get; set; }
	public string Comment { get; set; }
	public ICollection<AdCommentFile> Files { get; set; }
}