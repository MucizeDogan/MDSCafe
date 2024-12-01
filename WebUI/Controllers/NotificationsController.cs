using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.NotificationTypes = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "1 - notif-icon notif-primary" },
                new SelectListItem { Value = "2", Text = "2 - notif-icon notif-success" },
                new SelectListItem { Value = "3", Text = "3 - notif-icon notif-danger" }
            };

            ViewBag.Icons = new Dictionary<string, string>
            {
                { "1", "la la-user-plus" },
                { "2", "la la-comment" },
                { "3", "la la-heart" }
            };

            return View(new CreateNotificationDto());
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
            ViewBag.NotificationTypes = new List<SelectListItem>
            {
        new SelectListItem { Value = "1", Text = "1 - notif-icon notif-primary" },
        new SelectListItem { Value = "2", Text = "2 - notif-icon notif-success" },
        new SelectListItem { Value = "3", Text = "3 - notif-icon notif-danger" }
            };

            ViewBag.Icons = new Dictionary<string, string>
            {
                    { "1", "la la-user-plus" },
                    { "2", "la la-comment" },
                    { "3", "la la-heart" }
                };

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


        public async Task<IActionResult> NotificationStatusChangeToTrue(int id) {
            ViewBag.NotificationTypes = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "1 - notif-icon notif-primary" },
                new SelectListItem { Value = "2", Text = "2 - notif-icon notif-success" },
                new SelectListItem { Value = "3", Text = "3 - notif-icon notif-danger" }
            };

            ViewBag.Icons = new Dictionary<string, string>
            {
                 { "1", "la la-user-plus" },
                 { "2", "la la-comment" },
                 { "3", "la la-heart" }
            };

            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync($"https://localhost:7052/api/Notification/NotificationChangeToTrue/{id}");
            if (!res.IsSuccessStatusCode) {
                return View();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> NotificationStatusChangeToFalse(int id) {
            ViewBag.NotificationTypes = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "1 - notif-icon notif-primary" },
                new SelectListItem { Value = "2", Text = "2 - notif-icon notif-success" },
                new SelectListItem { Value = "3", Text = "3 - notif-icon notif-danger" }
            };

            ViewBag.Icons = new Dictionary<string, string>
            {
                 { "1", "la la-user-plus" },
                 { "2", "la la-comment" },
                 { "3", "la la-heart" }
            };

            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync($"https://localhost:7052/api/Notification/NotificationChangeToFalse/{id}");
            if (!res.IsSuccessStatusCode) {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAllNotificationByTrue() {
            var client = _httpClientFactory.CreateClient();
            var res = await client.PostAsync("https://localhost:7052/api/Notification/DeleteAllNotificationByTrue", null); // API'ye POST isteği gönderiyoruz
            if (res.IsSuccessStatusCode) {
                return RedirectToAction("Index"); // Başarılıysa anasayfaya yönlendir
            }
            return View(); // Başarısızsa aynı sayfada kal
        }
    }
}
