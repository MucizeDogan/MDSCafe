using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.BasketDto;

namespace WebUI.Controllers {
    [AllowAnonymous]
    public class BasketsController : Controller {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketsController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id) {
            TempData["x"] = id;
            var client = _httpClientFactory.CreateClient(); // Bir istemci oluşturdum.
            var res = await client.GetAsync("https://localhost:7052/api/Basket/BasketListByCafeTableWithProductName?id=" + id); // İstekte bulunacağımız apinin url sini yazıyoruz
            if (res.IsSuccessStatusCode) {
                var jsonData = await res.Content.ReadAsStringAsync(); // json dan gelen içerği string formatta oku
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData); // Json datayı çözüp normal metine dönüştürür(DeserializeObject)
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id) {
            int tableId = int.Parse(TempData["x"].ToString());
            var client = _httpClientFactory.CreateClient();
            var res = await client.DeleteAsync($"https://localhost:7052/api/Basket/{id}");
            if (res.IsSuccessStatusCode) {
                return RedirectToAction("Index", new {id = tableId });
            }
            return NoContent();
        }


    }
}
