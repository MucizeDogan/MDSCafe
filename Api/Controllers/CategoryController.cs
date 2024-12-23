using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.CategoryDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper) {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListCategory() {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto) {
            createCategoryDto.Status = true;
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(value);
            return Ok("Kategori başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Kategori başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto) {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            return Ok("Kategori başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id) {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount() {
            return Ok(_categoryService.TCategoryCount());
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount() {
            return Ok(_categoryService.TActiveCategoryCount());
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount() {
            return Ok(_categoryService.TPassiveCategoryCount());
        }
    }
}
