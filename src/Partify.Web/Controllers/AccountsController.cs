using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Partify.Service.Exceptions;
using Partify.Web.Models.Accounts;
using Partify.Web.WebServices.Accounts;
using System.Security.Claims;

namespace Partify.Web.Controllers;

public class AccountsController(IAccountWebService accountWebService) : Controller
{
    public IActionResult Login()
    {
        if (HttpContext.User.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Home");

        return View();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Login(LoginModel model)
    {
        try
        {
            var result = await accountWebService.LoginAsync(model);
            if(result is not null)
            {
                var claims = new List<Claim>
                {
                   new Claim("Id", result.Id.ToString()),
                   new Claim("Fullname", $"{result.FirstName} {result.LastName}"),
                   new Claim(ClaimTypes.Role, result.Role)
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(claimIdentity));

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        catch (ForbiddenException ex)
        {
            ViewBag.Exception = ex.Message;
        }

        return View();
    }

    public async ValueTask<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }
}
