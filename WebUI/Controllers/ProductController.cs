using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.CategoryDto;
using WebUI.Dtos.ProductDto;

namespace WebUI.Controllers {
    public class ProductController : Controller {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() {
            var client = _httpClientFactory.CreateClient(); // Bir istemci oluşturdum.
            var res = await client.GetAsync("https://localhost:7052/api/Product/ListProductWithCategory"); // İstekte bulunacağımız apinin url sini yazıyoruz
            if (res.IsSuccessStatusCode) {
                var jsonData = await res.Content.ReadAsStringAsync(); // json dan gelen içerği string formatta oku
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData); // Json datayı çözüp normal metine dönüştürür(DeserializeObject)
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task< IActionResult > CreateProduct() {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7052/api/Category");
            var jsonData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values    //values den al
                                            select new SelectListItem { //Ürün ekleme kısmında kategori seçtirmek için 
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.v = values2; //Değerleri taşımak için
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto) {
            createProductDto.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("https://localhost:7052/api/Product", stringContent);
            if (res.IsSuccessStatusCode) {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id) {
            var client = _httpClientFactory.CreateClient();
            var res = await client.DeleteAsync($"https://localhost:7052/api/Product/{id}");
            if (res.IsSuccessStatusCode) {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id) {
            var client2 = _httpClientFactory.CreateClient();
            var res2 = await client2.GetAsync("https://localhost:7052/api/Category");
            var jsonData2 = await res2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
            List<SelectListItem> values2_1 = (from x in values2   //values den al
                                            select new SelectListItem { //Ürün ekleme kısmında kategori seçtirmek için 
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.v = values2_1; //Değerleri taşımak için

            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync($"https://localhost:7052/api/Product/{id}");
            if (!res.IsSuccessStatusCode) {
                return View();
            }
            var jsonData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto) {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PutAsync("https://localhost:7052/api/Product/", stringContent);
            if (!res.IsSuccessStatusCode) {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
