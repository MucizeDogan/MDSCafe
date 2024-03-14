using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.DefaultComponents {
    public class _DefaultOutMenuComponentPartial : ViewComponent{
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
