using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Users;

public class Merchant : Auditable
{
	public long UserId { get; set; }
	public User User { get; set; }
}