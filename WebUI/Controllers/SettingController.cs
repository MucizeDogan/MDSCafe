using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Dtos.IdentityDto;

namespace WebUI.Controllers {
    [AllowAnonymous]
    public class SettingController : Controller {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager) {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new UserEditDto();
            userEditDto.Mail = values.Email;
            userEditDto.Name = values.Name;
            userEditDto.Surname = values.Surname;
            userEditDto.Username = values.UserName;
            return View(userEditDto);
        }
    }
}
