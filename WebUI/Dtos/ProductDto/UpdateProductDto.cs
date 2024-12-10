using System.ComponentModel.DataAnnotations;

namespace WebUI.Dtos.ProductDto {
    public class UpdateProductDto {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }
    }
}
