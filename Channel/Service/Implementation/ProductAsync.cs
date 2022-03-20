using ChannelEngine.Merchant.ApiClient.Model;
using Service.Interfaces;
using Service.Model;

namespace Service.Implementation
{
    public class ProductAsync : IProductAsync
    {
        IOrderApiAsync _orderApiAsync;
        public ProductAsync(IOrderApiAsync orderApiAsync)
        {
            _orderApiAsync = orderApiAsync;
        }
        public async Task<IEnumerable<TopSoldProduct>> GetTopSoldProduct(int number)
        {
            var result = await _orderApiAsync.OrderGetByFilterAsync(new OrderFilterOption()
            {
                Statuses = new List<OrderStatusView>()
            {
                OrderStatusView.IN_PROGRESS
            }
            });
            var rv = result.Content.SelectMany(x => x.Lines)
                .GroupBy(x => new { x.Gtin, x.Description, x.MerchantProductNo })
                          .Select(g => new TopSoldProduct(
                                  g.Key.Gtin,
                                  g.Key.Description,
                                  g.Sum(x => x.Quantity)
                          ))
                          .OrderByDescending(x => x.TotalQuantity).Take(number);
            return rv.ToList();
        }
    }
}
