using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.DefaultComponents {
    public class _DefaultAboutComponentPartial : ViewComponent{
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
