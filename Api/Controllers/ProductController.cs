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
            var values = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(values);

            //var context = new Context();
            //var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory {
            //    Description = y.Description,
            //    ImageUrl = y.ImageUrl,
            //    Price = y.Price,
            //    ProductName = y.ProductName,
            //    ProductID = y.ProductID,
            //    ProductStatus = y.ProductStatus,
            //    CategoryName = y.Category.CategoryName
            //});
            //return Ok(values.ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto) {

            var value = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);
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
            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id) {
            var value = _productService.TGetById(id);
            return Ok(_mapper.Map<GetProductDto>(value));
        }

        [HttpGet("ProductCount")] // ürün sayısı
        public IActionResult ProductCount() {
            return Ok(_productService.TCategoryCount());
        }

        [HttpGet("ProductCountByCategoryNameHamburger")] //KAtegorisi Hamburger olan ürünlerin sayısı
        public IActionResult ProductCountByCategoryNameHamburger() {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }

        [HttpGet("ProductCountByCategoryNameDrink")] //KAtegorisi İçecek olan ürünlerin sayısı
        public IActionResult ProductCountByCategoryNameDrink() {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }

        [HttpGet("ProductPriceAvg")] //Ürünlerin Ortalama Fiyatı
        public IActionResult ProductPriceAvg() {
            return Ok(_productService.TProductPriceAvg());
        }

        [HttpGet("ProductNameByPriceHighest")] //En Yüksek fiyatlı ürün 
        public IActionResult ProductNameByPriceHighest() {
            return Ok(_productService.TProductNameByPriceHighest());
        }

        [HttpGet("LowestPricedProductName")] //En Düşük Fiyatlı ürün
        public IActionResult LowestPricedProductName() {
            return Ok(_productService.TLowestPricedProductName());
        }

        [HttpGet("HamburgerAvg")] //En Düşük Fiyatlı ürün
        public IActionResult HamburgerAvg() {
            return Ok(_productService.THamburgerAvg());
        }
        
        [HttpGet("GetProductsPriceOver50")]
        public IActionResult GetProductsPriceOver50() {
            var value = _productService.TGetProductsPriceOver50();
            return Ok(value);
        }
    }
}
