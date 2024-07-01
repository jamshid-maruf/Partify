using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Users;

public class UserRole : Auditable
{
	public string Name { get; set; }
}
