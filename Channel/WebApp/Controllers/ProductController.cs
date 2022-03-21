using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Net;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiAsync _productApiAsync;

        public ProductController(IProductApiAsync productApiAsync)
        {
            _productApiAsync = productApiAsync;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _productApiAsync.GetTopSoldProduct(5);
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
