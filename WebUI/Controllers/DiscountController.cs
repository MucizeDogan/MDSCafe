using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.DiscountDto;

namespace WebUI.Controllers {
    public class DiscountController : Controller {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiscountController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() {
            var client = _httpClientFactory.CreateClient(); // Bir istemci oluşturdum.
            var res = await client.GetAsync("https://localhost:7052/api/Discount"); // İstekte bulunacağımız apinin url sini yazıyoruz
            if (res.IsSuccessStatusCode) {
                var jsonData = await res.Content.ReadAsStringAsync(); // json dan gelen içerği string formatta oku
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData); // Json datayı çözüp normal metine dönüştürür(DeserializeObject)
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateDiscount() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto) {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("https://localhost:7052/api/Discount", stringContent);
            if (res.IsSuccessStatusCode) {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteDiscount(int id) {
            var client = _httpClientFactory.CreateClient();
            var res = await client.DeleteAsync($"https://localhost:7052/api/Discount/{id}");
            if (res.IsSuccessStatusCode) {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id) {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync($"https://localhost:7052/api/Discount/{id}");
            if (!res.IsSuccessStatusCode) {
                return View();
            }
            var jsonData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto) {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PutAsync("https://localhost:7052/api/Discount/", stringContent);
            if (!res.IsSuccessStatusCode) {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
