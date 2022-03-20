using ChannelEngine.Merchant.ApiClient.Model;
using Service.Interfaces;
using Service.Model;

namespace Service.Implementation
{
    public class ProductApiAsync : IProductApiAsync
    {
        private readonly IOrderApiAsync _orderApiAsync;
        public ProductApiAsync(IOrderApiAsync orderApiAsync)
        {
            _orderApiAsync = orderApiAsync;
        }
        public async Task<IEnumerable<TopSoldProduct>> GetTopSoldProduct(int number)
        {
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
            return top5SoldProd.ToList();
        }
    }
}
