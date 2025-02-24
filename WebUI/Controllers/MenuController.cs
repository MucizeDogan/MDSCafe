﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.BasketDto;
using WebUI.Dtos.ProductDto;

namespace WebUI.Controllers {
    [AllowAnonymous]
    public class MenuController : Controller {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id) {
            ViewBag.v = id;
            var client = _httpClientFactory.CreateClient(); // Bir istemci oluşturdum.
            var res = await client.GetAsync("https://localhost:7052/api/Product/ListProductWithCategory"); // İstekte bulunacağımız apinin url sini yazıyoruz
            if (res.IsSuccessStatusCode) {
                var jsonData = await res.Content.ReadAsStringAsync(); // json dan gelen içerği string formatta oku
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData); // Json datayı çözüp normal metine dönüştürür(DeserializeObject)
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int id, int cafeTableId) {
            if (cafeTableId == 0 ) {
                return BadRequest("CafeTableId 0 geliyor.");
            }

            CreateBasketDto createBasketDto = new CreateBasketDto() {
                ProductID = id,
                CafeTableID = cafeTableId
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("https://localhost:7052/api/Basket", stringContent);

            var client2 = _httpClientFactory.CreateClient();
            await client2.GetAsync("https://localhost:7052/api/CafeTables/ChangeStatusTableStatusToTrue?id=" + cafeTableId);

            if (res.IsSuccessStatusCode) {
                return RedirectToAction("Index");
            }
            return Json(createBasketDto);
        }
    }
}
