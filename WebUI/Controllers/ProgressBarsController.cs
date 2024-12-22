using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers {
    public class ProgressBarsController : Controller {
        [AllowAnonymous]
        public IActionResult Index() {
            return View();
        }
    }
}
