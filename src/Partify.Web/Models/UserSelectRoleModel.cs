using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;
using Partify.Web.Models.Users;

namespace Partify.Web.Models;

public class UserSelectRoleModel
{
    public SelectRoleModel SelectRole { get; set; }
    public UserViewModel User { get; set; }
    public long UserRoleId { get; set; }
}

public class SelectRoleModel
{
    public long SelectedId { get; set; }
    public List<SelectListItem> UserRoles { get; set; }
}
