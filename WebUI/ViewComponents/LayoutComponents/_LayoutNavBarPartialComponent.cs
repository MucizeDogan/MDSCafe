using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.LayoutComponents {
    public class _LayoutNavBarPartialComponent : ViewComponent {

        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
