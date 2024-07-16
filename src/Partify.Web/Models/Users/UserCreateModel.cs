using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Partify.Web.Models.Users;

public class UserCreateModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
