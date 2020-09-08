using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YineBirCore.ViewModels;

namespace YineBirCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home"); 

        }
 

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.Rememberme, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");

                }

                    ModelState.AddModelError(string.Empty, "Hatalı giriş denemesi");

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnURL)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password); 

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);

                    if (Url.IsLocalUrl(returnURL)) {

                        return Redirect(returnURL);

                    } else
                    {
                         return RedirectToAction("index", "home"); 
                    }
                   
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description); 

                }

            }

            return View(model);
        }

        [Authorize]
        public IActionResult MySpecialPage()
        {
            if (signInManager.IsSignedIn(User))
            {
                  return View();

            }else
            {
                return RedirectToAction("index", "home"); 
            }
            
        }
    }
}