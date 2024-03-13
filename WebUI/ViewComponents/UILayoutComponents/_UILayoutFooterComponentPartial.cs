using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutComponents {
    public class _UILayoutFooterComponentPartial : ViewComponent {
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
