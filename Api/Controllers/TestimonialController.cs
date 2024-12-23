using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.TestimonialDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper) {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListTestimonial() {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto) {
            createTestimonialDto.Status = false;
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(value);
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id) {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto) {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id) {
            var value = _testimonialService.TGetById(id);
            return Ok(_mapper.Map<GetTestimonialDto>(value));
        }
    }
}
