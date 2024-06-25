namespace Partify.WebApi.Models.Users;

public class LoginViewModel
{
	public long Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public long Phone { get; set; }
	public string Email { get; set; }
	public string Token { get; set; }
}
