using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers {
    [AllowAnonymous]
    public class UILayoutController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
