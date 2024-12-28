using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.Dtos.CategoryDto;

namespace WebUI.ViewComponents.MenuComponents {
    public class _MenuCategoryFilterComponentPartial : ViewComponent {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MenuCategoryFilterComponentPartial(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var client = _httpClientFactory.CreateClient(); // Bir istemci oluşturdum.
            var res = await client.GetAsync("https://localhost:7052/api/Category"); // İstekte bulunacağımız apinin url sini yazıyoruz
            if (res.IsSuccessStatusCode) {
                var jsonData = await res.Content.ReadAsStringAsync(); // json dan gelen içerği string formatta oku
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData); // Json datayı çözüp normal metine dönüştürür(DeserializeObject)
                return View(values);
            }
            return View();
        }
    }
}
