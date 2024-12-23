using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.SliderDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper) {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListSlider() {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            //var values = _sliderService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto) {

            var value = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(value);
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id) {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto) {
            var value = _mapper.Map<Slider>(updateSliderDto);
            _sliderService.TUpdate(value);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id) {
            var value = _sliderService.TGetById(id);
            return Ok(_mapper.Map<GetSliderDto>(value));
        }
    }
}
