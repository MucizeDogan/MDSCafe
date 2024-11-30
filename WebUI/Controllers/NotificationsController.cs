using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.NotificationDto;

namespace WebUI.Controllers {
    public class NotificationsController : Controller {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationsController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() {
            var client = _httpClientFactory.CreateClient(); // Bir istemci oluşturdum.
            var res = await client.GetAsync("https://localhost:7052/api/Notification"); // İstekte bulunacağımız apinin url sini yazıyoruz
            if (res.IsSuccessStatusCode) {
                var jsonData = await res.Content.ReadAsStringAsync(); // json dan gelen içerği string formatta oku
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData); // Json datayı çözüp normal metine dönüştürür(DeserializeObject)
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateNotification() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto) {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNotificationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("https://localhost:7052/api/Notification", stringContent);
            if (res.IsSuccessStatusCode) {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteNotification(int id) {
            var client = _httpClientFactory.CreateClient();
            var res = await client.DeleteAsync($"https://localhost:7052/api/Notification/{id}");
            if (res.IsSuccessStatusCode) {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id) {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync($"https://localhost:7052/api/Notification/{id}");
            if (!res.IsSuccessStatusCode) {
                return View();
            }
            var jsonData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto) {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateNotificationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PutAsync("https://localhost:7052/api/Notification/", stringContent);
            if (!res.IsSuccessStatusCode) {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
