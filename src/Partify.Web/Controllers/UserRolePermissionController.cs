using Microsoft.AspNetCore.Mvc;
using Partify.Web.WebServices.UserRolePermissions;

namespace Partify.Web.Controllers
{
    public class UserRolePermissionController(IUserRolePermissionWebService userRolePermissionWebService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
