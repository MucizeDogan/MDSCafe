using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.BookingDto;

namespace WebUI.Controllers {
    [AllowAnonymous]
    public class BookATableController : Controller {

        private readonly IHttpClientFactory _httpClientFactory;
        public BookATableController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto) {
            var client = _httpClientFactory.CreateClient();
            createBookingDto.Description = "aaa";
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            

            var res = await client.PostAsync("https://localhost:7052/api/Booking", stringContent);
            if (res.IsSuccessStatusCode) {
                ViewBag.SuccessMessage = $"Tarih: {createBookingDto.Date.ToShortDateString()}, Kişi Sayısı: {createBookingDto.PersonCount}";
                return RedirectToAction("Index","Default");
            } else {
                var errorContent = await res.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                ViewBag.ErrorMessage = "Lütfen tekrar deneyiniz.";
                return View();
            }

            
        }
    }
}
