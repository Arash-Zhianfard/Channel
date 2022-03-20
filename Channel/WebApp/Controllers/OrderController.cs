using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Model;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {
        IOrderApiAsync _orderApiAsync;
        public OrderController(IOrderApiAsync orderApiAsync)
        {
            this._orderApiAsync = orderApiAsync;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _orderApiAsync.OrderGetByFilterAsync(new OrderFilterOption()
            {
                Statuses = new List<ChannelEngine.Merchant.ApiClient.Model.OrderStatusView>()
            {
                ChannelEngine.Merchant.ApiClient.Model.OrderStatusView.IN_PROGRESS
            }
            });
            return View(result.Content);
            
        }

        
    }
}
