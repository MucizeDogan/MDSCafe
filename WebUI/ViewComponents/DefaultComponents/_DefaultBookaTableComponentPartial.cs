using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.DefaultComponents {
    public class _DefaultBookaTableComponentPartial : ViewComponent {
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
