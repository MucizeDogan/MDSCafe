using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService) {
            _orderService = orderService;
        }
        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount() { // Toplam Sipariş Sayısı
            return Ok(_orderService.TTotalOrderCount());
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount() { // Aktif Sipariş Sayısı
            return Ok(_orderService.TActiveOrderCount());
        }

        [HttpGet("LastOrderTotalPrice")]
        public IActionResult LastOrderTotalPrice() { // Aktif Sipariş Sayısı
            return Ok(_orderService.TLastOrderTotalPrice());
        }
    }
}
