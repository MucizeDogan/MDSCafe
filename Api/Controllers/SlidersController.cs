using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService) {
            _sliderService = sliderService;
        }

        [HttpGet]
        public IActionResult GetAllSliders() {
            return Ok(_sliderService.TGetListAll());
        }
    }
}
