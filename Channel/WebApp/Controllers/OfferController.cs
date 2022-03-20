using Microsoft.AspNetCore.Mvc;
using Service.Implementation;

namespace WebApp.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferApiSync _offerApiSync;
        public OfferController(IOfferApiSync offerApiSync)
        {
            _offerApiSync = offerApiSync;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _offerApiSync.UpdateStockCountAsync();
            return View(result);
        }
    }
}
