using ChannelEngine.Merchant.ApiClient.Model;
using Service.Interfaces;
using Service.Model;

namespace Service.Implementation
{
    public class StockCharger : IStockCharger
    {
        private readonly IOrderApiAsync _orderApiAsync;
        private readonly IOfferApiSync _offerApiSync;
        const int stockValue = 25;
        public StockCharger(IOrderApiAsync orderApiAsync, IOfferApiSync offerApiSync)
        {
            _orderApiAsync = orderApiAsync;
            _offerApiSync = offerApiSync;
        }
        public async Task<UpdateStockResponse> UpdateStockCountAsync()
        {
            var inProgressOrders = await _orderApiAsync.GetByFilterAsync(new OrderFilterOption { Statuses = new List<OrderStatusView> { OrderStatusView.IN_PROGRESS } });
            var firstLine = inProgressOrders.Content.FirstOrDefault()?.Lines.FirstOrDefault();
            var stockUpdateResponse = await _offerApiSync.OfferStockUpdateAsync(new List<MerchantOfferStockUpdateRequest> {
            new MerchantOfferStockUpdateRequest
            {
                MerchantProductNo=  firstLine.MerchantProductNo,
                StockLocations=new List<MerchantStockLocationUpdateRequest>()
                {
                    new MerchantStockLocationUpdateRequest
                    {
                        Stock = stockValue,
                        StockLocationId = firstLine.StockLocation.StockLocationId
                    }
                }
            }
            });
            return stockUpdateResponse;
        }

    }
}
