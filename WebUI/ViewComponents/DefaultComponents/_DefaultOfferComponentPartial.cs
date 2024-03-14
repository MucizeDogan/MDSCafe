using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.DefaultComponents {
    public class _DefaultOfferComponentPartial : ViewComponent{
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
