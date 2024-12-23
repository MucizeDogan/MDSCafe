using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.AboutDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper) {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListAbout() {
            var values = _aboutService.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto) {
            var value = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(value);
            return Ok("Hakkımızda kısmı başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id) {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımızda alanı başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto) {
            var value = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value);
            return Ok("Hakkımızda alanı başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id) {
            var value = _aboutService.TGetById(id);
            return Ok(_mapper.Map<GetAboutDto>(value));
        }
    }
}