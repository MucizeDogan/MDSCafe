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

        public async Task SendStatistics() {  
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value); // Burada gelen değeri client tarafına gönderme

            var value2 = _productService.TCategoryCount(); // Normalde Product count olacaktı
            await Clients.All.SendAsync("ReceiveProductCount", value2); // Burada gelen değeri client tarafına gönderme

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategeryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePasiveCategeryCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5);

            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6);

            var value7 = _productService.TProductPriceAvg().ToString("#0.00") + " ₺";
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7);

            var value8 = _productService.TProductNameByPriceHighest();
            await Clients.All.SendAsync("ReceiveProductNameByPriceHighest", value8);
        }

    }
}
