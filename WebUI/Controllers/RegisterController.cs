using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Dtos.IdentityDto;

namespace WebUI.Controllers {
    public class RegisterController : Controller {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager) {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto) {
            var appUser = new AppUser() {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Mail,
                UserName = registerDto.Username
            };
            var result = await _userManager.CreateAsync(appUser,registerDto.Password);
            if (result.Succeeded) {
                return RedirectToAction("Index", "Login");
            }
			ViewBag.Errors = result.Errors.Select(e => e.Description).ToList();
			return View();
        }
    }
}
