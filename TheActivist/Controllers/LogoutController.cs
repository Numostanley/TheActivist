using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheActivist.Models;

namespace TheActivist.Controllers
{
    // The codes for this controller was aided through the youtube resource : https://www.youtube.com/watch?v=B0_gM-wBlmE
    public class LogoutController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public LogoutController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logout(string returnUrl)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login", new { area = "" });
        }

        public IActionResult DontLogout(string returnUrl)
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
