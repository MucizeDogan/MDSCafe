using DtoLayer.ContactMeDto;
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
        public async Task<PartialViewResult> SendMessage() {
            var client = _httpClientFactory.CreateClient(); // Bir istemci oluşturdum.
            var res = await client.GetAsync("https://localhost:7052/api/ContactMe"); // İstekte bulunacağımız apinin url sini yazıyoruz
            if (res.IsSuccessStatusCode) {
                var jsonData = await res.Content.ReadAsStringAsync(); // json dan gelen içerği string formatta oku
                var values = JsonConvert.DeserializeObject<ResultContactMeDto>(jsonData); // Json datayı çözüp normal metine dönüştürür(DeserializeObject)
                ViewBag.Location = values.Location;
                return PartialView(values);
            }
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
