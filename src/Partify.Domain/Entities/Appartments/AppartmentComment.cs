using Partify.Domain.Commons;
using Partify.Domain.Entities.Users;

namespace Partify.Domain.Entities.Appartments;

public class AppartmentComment : Auditable
{
	public long UserId { get; set; }
	public User User { get; set; }
	public long AppartmentId { get; set; }
	public Appartment Appartment { get; set; }
	public string Comment { get; set; }
	public ICollection<AppartmentCommentFile> Files { get; set; }
}