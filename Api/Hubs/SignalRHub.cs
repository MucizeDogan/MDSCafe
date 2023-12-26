using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs {
    public class SignalRHub : Hub{
        Context context = new Context();
        
        public async Task SendCategoryCount() {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value); // Burada gelen değeri client tarafına gönderme

        }
    }
}
