using Microsoft.AspNetCore.Mvc;
using Service.Implementation;
using Service.Interfaces;

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
            var result = await _stockCharger.UpdateStockCountAsync();
            return View(result);
        }
    }
}
