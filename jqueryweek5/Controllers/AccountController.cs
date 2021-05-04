using jqueryweek5.DataRepositories;
using jqueryweek5.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace jqueryweek5.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAdminRepository _adminRepository;

        public AccountController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckLogin(string name, string password)
        {
            if (!_adminRepository.LoginCheck(name, password))
            {
                return Json("用户名或密码错误。");
            }
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.Name,model.Name),new Claim("password",model.Password)
            };

            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Customer"));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                IsPersistent = false,
                AllowRefresh = false
            });

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
