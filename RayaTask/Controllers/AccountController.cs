using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RayaTask.ViewModels;

namespace RayaTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<RayaUser> userManager;
        private readonly SignInManager<RayaUser> signInManager;

        public AccountController(UserManager<RayaUser> userManager,SignInManager<RayaUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, true, false) ;
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");

            }
            else 
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                //foreach (var item in result.er)
                //{
                //    ModelState.AddModelError("", item.Description);
                //}
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            var user = new RayaUser()
            {
                UserName = model.Email,
                Email = model.Email,                
            };
            var result = await userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Login");

            }
            else
            {
                foreach(var item  in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View();
        }
        
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return Redirect("Login");
        }

    }
}
    


