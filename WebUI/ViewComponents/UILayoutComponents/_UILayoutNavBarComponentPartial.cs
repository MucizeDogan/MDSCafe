using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutComponents {
    public class _UILayoutNavBarComponentPartial : ViewComponent {
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
