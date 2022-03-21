using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Model;
using System.Net;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiAsync _orderApiAsync;
        public OrderController(IOrderApiAsync orderApiAsync)
        {
            this._orderApiAsync = orderApiAsync;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _orderApiAsync.GetByFilterAsync(new OrderFilterOption()
                {
                    Statuses = new List<ChannelEngine.Merchant.ApiClient.Model.OrderStatusView>()
            {
                ChannelEngine.Merchant.ApiClient.Model.OrderStatusView.IN_PROGRESS
            }
                });
                if (result.Success)
                    return View(result.Content);
                return View("Error", new ErrorViewModel() { Message = result.Message, Code = (int)HttpStatusCode.InternalServerError });
            }
            catch (Exception ex)
            {
                //log
                return View("Error", new ErrorViewModel() { Message = "somthing went wrong", Code = (int)HttpStatusCode.InternalServerError });
            }
        }
    }
}
