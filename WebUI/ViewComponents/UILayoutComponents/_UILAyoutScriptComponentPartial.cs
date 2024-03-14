using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutComponents {
    public class _UILAyoutScriptComponentPartial : ViewComponent{
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
