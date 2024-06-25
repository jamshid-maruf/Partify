using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Users;

public class User : Auditable
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public long Phone { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
}