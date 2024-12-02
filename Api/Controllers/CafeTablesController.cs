using BusinessLayer.Abstract;
using DtoLayer.CafeTableDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CafeTablesController : ControllerBase {
        private readonly ICafeTableService _cafeTableService;

        public CafeTablesController(ICafeTableService cafeTableService) {
            _cafeTableService = cafeTableService;
        }

        [HttpGet("CafeTableCount")]
        public IActionResult CafeTableCount() {
            return Ok(_cafeTableService.TCafeTableCount());
        }

        [HttpGet]
        public IActionResult ListCafeTable() {
            var values = _cafeTableService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCafeTable(CreateCafeTableDto createCafeTableDto) {
            CafeTable cafeTable = new CafeTable() {
                Name = createCafeTableDto.Name,
                Status = false
            };
            _cafeTableService.TAdd(cafeTable);
            return Ok("Yeni Masa başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCafeTable(int id) {
            var value = _cafeTableService.TGetById(id);
            _cafeTableService.TDelete(value);
            return Ok("Masa başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateCafeTable(UpdateCafeTableDto updateCafeTableDto) {
            CafeTable cafeTable = new CafeTable() {
                CafeTableID = updateCafeTableDto.CafeTableID,
                Name = updateCafeTableDto.Name,
                Status = updateCafeTableDto.Status
            };
            _cafeTableService.TUpdate(cafeTable);
            return Ok("Masa başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCafeTable(int id) {
            var value = _cafeTableService.TGetById(id);
            return Ok(value);
        }
    }
}
