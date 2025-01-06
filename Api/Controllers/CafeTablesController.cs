using AutoMapper;
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
        private readonly IMapper _mapper;

        public CafeTablesController(ICafeTableService cafeTableService, IMapper mapper) {
            _cafeTableService = cafeTableService;
            _mapper = mapper;
        }

        [HttpGet("CafeTableCount")]
        public IActionResult CafeTableCount() {
            return Ok(_cafeTableService.TCafeTableCount());
        }

        [HttpGet]
        public IActionResult ListCafeTable() {
            var values = _cafeTableService.TGetListAll();
            return Ok(_mapper.Map<List<ResultCafeTableDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateCafeTable(CreateCafeTableDto createCafeTableDto) {
            createCafeTableDto.Status = false;
            var value = _mapper.Map<CafeTable>(createCafeTableDto);
            _cafeTableService.TAdd(value);
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
            var value = _mapper.Map<CafeTable>(updateCafeTableDto);
            _cafeTableService.TUpdate(value);
            return Ok("Masa başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCafeTable(int id) {
            var value = _cafeTableService.TGetById(id);
            return Ok(_mapper.Map<GetCafeTableDto>(value));
        }

        [HttpGet("ChangeStatusTableStatusToTrue")]
        public IActionResult ChangeStatusTableStatusToTrue(int id) {
            _cafeTableService.TChangeStatusTableStatusToTrue(id);
            return Ok("Masa Dolu durumuna değiştirildi.");
        }

        [HttpGet("ChangeStatusTableStatusToFalse")]
        public IActionResult ChangeStatusTableStatusToFalse(int id) {
            _cafeTableService.TChangeStatusTableStatusToFalse(id);
            return Ok("Masa Boş durumuna değiştirildi.");
        }
    }
}
