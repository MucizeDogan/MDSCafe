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

        public AboutController(IAboutService aboutService) {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult ListAbout() {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto) {
            About about = new About() {
                ImageUrl = createAboutDto.ImageUrl,
                Description = createAboutDto.Description,
                Title = createAboutDto.Title
            };
            _aboutService.TAdd(about);
            return Ok("Hakkımızda kısmı başarılı bir şekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id) {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımızda alanı başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto) {
            About about = new About() {
                AboutID = updateAboutDto.AboutID,
                Description = updateAboutDto.Description,
                Title = updateAboutDto.Title,
                ImageUrl = updateAboutDto.ImageUrl
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımızda alanı başarıyla güncellendi");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id) {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}