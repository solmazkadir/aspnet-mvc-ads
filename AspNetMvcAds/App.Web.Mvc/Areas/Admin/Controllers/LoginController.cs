using App.Data.Entity;
using App.Web.Mvc.Models;
using AspNetMvcAds.Service.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNetMvcAds.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
		private readonly IService<User> _service;

		public LoginController(IService<User> userService)
		{
            _service = userService;
		}
		public IActionResult Index(string ReturnUrl)
        {
            var model = new AdminLoginViewModel();
            model.ReturnUrl = ReturnUrl;
            return View(model);
        }
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(); 
            return Redirect("/Admin/Login"); 
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(AdminLoginViewModel admin)
        {
            try
            {
                var kullanici = await _service.GetAsync(k => k.IsActive && k.Email == admin.Email && k.Password == admin.Password);
                if (kullanici != null)
                {
                    var kullaniciYetkileri = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, kullanici.Email),
                        new Claim("Role", kullanici.IsAdmin ? "Admin" : "User"),
                        new Claim("UserGuid", kullanici.UserGuid.ToString())
                    };
                    var kullaniciKimligi = new ClaimsIdentity(kullaniciYetkileri, "Login");
                    ClaimsPrincipal principal = new(kullaniciKimligi);
                    await HttpContext.SignInAsync(principal); 
                    return Redirect("/Admin/Main");
                }
                else  

                    ModelState.AddModelError("", "Giriş Başarısız!");

            }
            catch (Exception hata)
            {
                ModelState.AddModelError("", "Hata Oluştu!" + hata.Message);
            }
            return View();
        }
    }
}
