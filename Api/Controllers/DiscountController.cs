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

            _discountService.TAdd(new Discount() {
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                ImageUrl=createDiscountDto.ImageUrl,    
                Title = createDiscountDto.Title,
            });
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
            _discountService.TUpdate(new Discount() {
                DiscountID = updateDiscountDto.DiscountID,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl,
                Title = updateDiscountDto.Title
            });
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id) {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }
    }
}
