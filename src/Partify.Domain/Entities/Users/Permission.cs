using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Users;

public class Permission : Auditable
{
	public string Controller { get; set; }
	public string Action { get; set; }
}
