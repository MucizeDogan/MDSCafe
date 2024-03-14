using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.DefaultComponents {
    public class _DefaultSliderComponentPartial  : ViewComponent{
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
