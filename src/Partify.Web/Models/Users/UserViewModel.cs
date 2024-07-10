using Partify.Web.Models.UserRoles;

namespace Partify.Web.Models.Users;

public class UserViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long Phone { get; set; }
    public string Email { get; set; }
    public UserRoleViewModel Role { get; set; }
}