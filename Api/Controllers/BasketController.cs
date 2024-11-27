using Api.Model;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.BasketDto;
using EntityLayer.Entities;
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

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto) {
            using var context = new Context();
            _basketService.TAdd(new Basket() {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                CafeTableID=1,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0
            });
            return Ok();
        }
    }
}
