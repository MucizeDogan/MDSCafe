using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiscountDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper) {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListDiscount() {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto) {

            var value = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(value);
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id) {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto) {
            var value = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(value);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id) {
            var value = _discountService.TGetById(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));
        }

        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id) {
            _discountService.TChangeStatusToTrue(id);
            return Ok("Ürün İndirimi Aktif");
        }
        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id) {
            _discountService.TChangeStatusToFalse(id);
            return Ok("Ürün İndirimi Pasif");
        }

    }
}
