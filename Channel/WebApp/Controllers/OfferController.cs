using Microsoft.AspNetCore.Mvc;
using Service.Implementation;
using Service.Interfaces;
using System.Net;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OfferController : Controller
    {
        private readonly IStockCharger _stockCharger;
        public OfferController(IStockCharger stockCharger)
        {
            _stockCharger = stockCharger;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _stockCharger.UpdateStockCountAsync();
                if (result.Success)
                    return View(result);
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
