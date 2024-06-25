using Partify.Domain.Commons;
using Partify.Domain.Entities.Users;

namespace Partify.Domain.Entities.Appartments;

public class AppartmentScore : Auditable
{
	public int Score { get; set; }
	public long UserId { get; set; }
	public User User { get; set; }
	public long AppartmentId { get; set; }
	public Appartment Appartment { get; set; }
}
