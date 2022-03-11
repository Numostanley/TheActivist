using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheActivist.Models;

namespace TheActivist.Controllers
{
    public class RegisterController : Controller
    {
        // The codes for this controller was aided through the youtube resource : https://www.youtube.com/watch?v=B0_gM-wBlmE
        public Register Model { get; set; }
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }

        public RegisterController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        //Get
        public IActionResult Index()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Register register)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = register.UserName,
                    Email= register.Email,
                    //Is_Admin = true,


                };

                var result =  await UserManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                };
            }

            return View();
        }
    }
}
