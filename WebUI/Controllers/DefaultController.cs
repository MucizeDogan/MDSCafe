using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using WebUI.Dtos.MessageDto;

namespace WebUI.Controllers {
    [AllowAnonymous]
    public class DefaultController : Controller {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage() {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto) {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("https://localhost:7052/api/Message", stringContent);
            if (res.IsSuccessStatusCode) {
                ViewBag.SuccessMessage = "Mesajınız Gönderildi...";
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Mesajınız Gönderilemedi...!";
            return View();
        }
    }
}
