using ChannelEngine.Merchant.ApiClient.Model;
using Service.Interfaces;
using Service.Model;
using System.Net;

namespace Service.Implementation
{
    public class ProductApiAsync : IProductApiAsync
    {
        private readonly IOrderApiAsync _orderApiAsync;
        public ProductApiAsync(IOrderApiAsync orderApiAsync)
        {
            _orderApiAsync = orderApiAsync;
        }
        public async Task<TopSoldProductResponse> GetTopSoldProduct(int number)
        {
            try
            {
                var response = new TopSoldProductResponse();
                var result = await _orderApiAsync.GetByFilterAsync(new OrderFilterOption()
                {
                    Statuses = new List<OrderStatusView>()
            {
                OrderStatusView.IN_PROGRESS
            }
                });
                var top5SoldProd = result.Content.SelectMany(x => x.Lines)
                    .GroupBy(x => new { x.Gtin, x.Description, x.MerchantProductNo })
                              .Select(g => new TopSoldProduct(
                                      g.Key.Gtin,
                                      g.Key.Description,
                                      g.Sum(x => x.Quantity)
                              ))
                              .OrderByDescending(x => x.TotalQuantity).Take(number);
                response.Content = top5SoldProd;
                return response;
            }

            catch (Exception ex)
            {
                return new TopSoldProductResponse()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "something went wrong",
                    Success = false
                };
            }
        }
    }
}
