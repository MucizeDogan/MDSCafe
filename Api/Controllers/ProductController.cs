using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.PoductDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            //var values = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            //return Ok(values);

            var context = new Context();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductName = y.ProductName,
                ProductID = y.ProductID,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto) {

            _productService.TAdd(new Product() {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                ProductStatus = createProductDto.ProductStatus,
                CategoryID=createProductDto.CategoryID
            });
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete("{id}")]
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
                CategoryID = updateProductDto.CategoryID
            });
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id) {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
    }
}
