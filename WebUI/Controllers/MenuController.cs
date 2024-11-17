using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers {
    public class MenuController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
