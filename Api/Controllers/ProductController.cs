using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.PoductDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper) {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListProduct() {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("ListProductWithCategory")]
        public IActionResult ListProductWithCategory() {
            var values = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto) {

            _productService.TAdd(new Product() {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                ProductStatus = createProductDto.ProductStatus,
            });
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id) {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto) {
            _productService.TUpdate(new Product() {
                ProductID=updateProductDto.ProductID,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Price = updateProductDto.Price,
                ProductName = updateProductDto.ProductName,
                ProductStatus = updateProductDto.ProductStatus,
            });
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id) {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
    }
}
