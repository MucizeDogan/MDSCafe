using Api.Model;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("BasketListByCafeTableWithProductName")]
        public IActionResult BasketListByCafeTableWithProductName(int id) {
             using var context = new Context();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.CafeTableID == id).Select(z => new ResultBasketByCafeTableWithProductNameList {
                BasketID = z.BasketID,
                CafeTableID = z.CafeTableID,
                Count = z.Count,
                Price = z.Price,
                TotalPrice = z.TotalPrice,
                ProductID = z.ProductID,
                ProductName = z.Product.ProductName
            }).ToList();
            return Ok(values);
        }
    }
}
