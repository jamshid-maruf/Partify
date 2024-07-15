using Microsoft.AspNetCore.Mvc;
using Partify.Web.Models;
using Partify.Web.Models.UserRolePermissions;
using Partify.Web.WebServices.UserRolePermissions;
using Partify.Web.WebServices.UserRoles;

namespace Partify.Web.Controllers
{
    public class UserRolePermissionsController
        (IUserRolePermissionWebService userRolePermissionWebService,
        IUserRoleWebService userRoleWebService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var userRolePermissions = await userRolePermissionWebService.GetAllAsync();
            return View(userRolePermissions);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.UserRoles = await userRoleWebService.GetAllAsync();
            //ViewBag.Permissions = await permissionWebService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRolePermissionCreateModel createModel)
        {
            if (ModelState.IsValid)
            {
                var result = await userRolePermissionWebService.CreateAsync(createModel);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.UserRoles = await userRoleWebService.GetAllAsync();
           // ViewBag.Permissions = await permissionWebService.GetAllAsync();
            return View(createModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var userRolePermission = await userRolePermissionWebService.GetByIdAsync(id);
            if (userRolePermission == null)
            {
                return NotFound();
            }

            ViewBag.UserRoles = await userRoleWebService.GetAllAsync();
            //ViewBag.Permissions = await permissionWebService.GetAllAsync();
            return View(userRolePermission);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, UserRolePermissionUpdateModel updateModel)
        {
            if (ModelState.IsValid)
            {
                var result = await userRolePermissionWebService.UpdateAsync(id, updateModel);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.UserRoles = await userRoleWebService.GetAllAsync();
           // ViewBag.Permissions = await permissionWebService.GetAllAsync();
            return View(updateModel);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var result = await userRolePermissionWebService.DeleteAsync(id);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
