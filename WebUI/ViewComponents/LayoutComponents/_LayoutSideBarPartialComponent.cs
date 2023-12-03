using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.LayoutComponents {
    public class _LayoutSideBarPartialComponent : ViewComponent{
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
