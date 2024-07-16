namespace Partify.Web.Models.Users;

public class UserChangeRoleModel
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
    public string Fullname { get; set; }
}