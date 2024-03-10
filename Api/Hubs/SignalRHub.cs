using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs {
    public class SignalRHub : Hub{
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public SignalRHub(ICategoryService categoryService, IProductService productService) {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task SendCategoryCount() {  
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value); // Burada gelen değeri client tarafına gönderme
        }

        public async Task SendProductCount() {
            var value2 = _productService.TCategoryCount(); // Normalde Product count olacaktı
            await Clients.All.SendAsync("ReceiveProductCount", value2); // Burada gelen değeri client tarafına gönderme
        }
    }
}
