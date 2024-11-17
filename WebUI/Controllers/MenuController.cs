using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.ProductDto;

namespace WebUI.Controllers {
    public class MenuController : Controller {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() {
            var client = _httpClientFactory.CreateClient(); // Bir istemci oluşturdum.
            var res = await client.GetAsync("https://localhost:7052/api/Product"); // İstekte bulunacağımız apinin url sini yazıyoruz
            if (res.IsSuccessStatusCode) {
                var jsonData = await res.Content.ReadAsStringAsync(); // json dan gelen içerği string formatta oku
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData); // Json datayı çözüp normal metine dönüştürür(DeserializeObject)
                return View(values);
            }
            return View();
        }
    }
}
