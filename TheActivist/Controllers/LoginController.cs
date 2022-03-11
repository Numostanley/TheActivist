using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheActivist.Models;

namespace TheActivist.Controllers
{
    // The codes for this controller was aided through the youtube resource : https://www.youtube.com/watch?v=B0_gM-wBlmE
    public class LoginController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public Login Model { get; set; }
        public LoginController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        

        //Get
        public IActionResult Index()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Login login)
        {
            if (ModelState.IsValid)
            {
                var IdentityResult = await signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);
                if (IdentityResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }

            ModelState.AddModelError("", "Username or Password not corrct");
            return View();
        }
    }
}
