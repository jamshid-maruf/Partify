using Partify.Domain.Entities.Users;
using X.PagedList;

namespace Partify.Web.Models.Permissions;

public class PermissionPagedListModel
{
    public string Search { get; set; }
    public int? PageIndex { get; set; }
    public IPagedList<Permission> Permissions { get; set; }
}