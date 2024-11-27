using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs {
    public class SignalRHub : Hub{
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IOrderService _orderService;
        private readonly ICafeTableService _cafeTableService;
        private readonly IBookingService _bookingService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IMoneyCaseService moneyCaseService, IOrderService orderService, ICafeTableService cafeTableService, IBookingService bookingService) {
            _categoryService = categoryService;
            _productService = productService;
            _moneyCaseService = moneyCaseService;
            _orderService = orderService;
            _cafeTableService = cafeTableService;
            _bookingService = bookingService;
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

            var value9 = _moneyCaseService.TTotalMoneyCase().ToString("0.00") + " ₺";
            await Clients.All.SendAsync("ReceiveTotalMoneyCase", value9);

            var value10 = _orderService.TTodayTotalPrice().ToString("0.00") + " ₺";
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", value10);

            var value11 = _orderService.TLastOrderTotalPrice().ToString("0.00") + " ₺";
            await Clients.All.SendAsync("ReceiveLastOrderTotalPrice", value11);

            var value12 = _productService.TLowestPricedProductName();
            await Clients.All.SendAsync("ReceiveLowestPricedProductName", value12);

            var value13 = _productService.THamburgerAvg().ToString("0.00") + " ₺";
            await Clients.All.SendAsync("ReceiveHamburgerAvg", value13);

            var value14 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value14);

            var value15 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value15);

            var value16 = _cafeTableService.TCafeTableCount();
            await Clients.All.SendAsync("ReceiveCafeTableCount", value16);
        }

        public async Task SendProgress() {
            var value = _moneyCaseService.TTotalMoneyCase().ToString("0.00") + " ₺";
            await Clients.All.SendAsync("ReceiveTotalMoneyCase", value);

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);

            var value3 = _cafeTableService.TCafeTableCount();
            await Clients.All.SendAsync("ReceiveCafeTableCount", value3);
        }

        public async Task GetBookingList() {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

    }
}
