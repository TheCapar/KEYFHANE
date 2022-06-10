using KeyfHane.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace KeyfHane.Controllers
{
    public class LoginController : Controller
    {
        Context db = new Context();
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login(User user)
        {
            var bilgiler = db.Users.FirstOrDefault(
                a => a.Number == user.Number &&
                a.Password == user.Password);
            if (bilgiler != null)
            {
                if (user.Number.Substring(0, 1) == "5")
                {
                    if (user.Number.Length == 10)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Number)
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, "Login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(principal);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
    }
}
