using Microsoft.AspNetCore.Mvc;
using Partify.Service.Exceptions;
using Partify.Web.Models.Accounts;
using Partify.Web.WebServices.Accounts;

namespace Partify.Web.Controllers;

public class AccountsController(IAccountWebService accountWebService) : Controller
{
    public IActionResult Login()
    {
        if (HttpContext.User.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Home");

        return View();
    }

    public async ValueTask<IActionResult> Login(LoginModel model)
    {
        try
        {
            var result = await accountWebService.LoginAsync(model);
            if(result is not null)
            {

            }

            return View(model);
        }
        catch (ForbiddenException ex)
        {
            ViewBag.Exception = ex.Message;
        }

        return View();
    }

    public IActionResult Logout()
    {
        return View();
    }
}
