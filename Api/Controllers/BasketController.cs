using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService) {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByCafeTableID(int id) {

            var values = _basketService.TGetBasketByCafeTableNumber(id);
            return Ok(values);
        }
    }
}
