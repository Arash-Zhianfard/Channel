using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductApiAsync _productApiAsync;

        public ProductController(IProductApiAsync productApiAsync)
        {
            _productApiAsync = productApiAsync;
        }

        public async Task<IActionResult> Index()
        {
            var result =await _productApiAsync.GetTopSoldProduct(5);
            return View(result);
        }
    }
}
