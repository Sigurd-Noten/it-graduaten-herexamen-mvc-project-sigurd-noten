using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Aanvraagformulier.Models;
using System.Threading.Tasks;
using Aanvraagformulier.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

public class AccountController : Controller
{
    
        public IActionResult Login()
    {
        ClaimsPrincipal claimUser = HttpContext.User;

        if (claimUser.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Home");


        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(CustomUser modelLogin)
    {

        if (modelLogin.UserName == "user@example.com" &&
            modelLogin.PasswordHash == "123"
            )
        {
            List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.UserName),
                    new Claim("OtherProperties","Example Role")

                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }



        ViewData["ValidateMessage"] = "user not found";
        return View();
    }
}

