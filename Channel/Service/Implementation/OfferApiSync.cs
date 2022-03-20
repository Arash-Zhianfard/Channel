using ChannelEngine.Merchant.ApiClient.Model;
using Microsoft.Extensions.Options;
using Service.Interfaces;
using Service.Model;

namespace Service.Implementation
{
    public class OfferApiSync : IOfferApiSync
    {
        string _baseUrl;
        string _token;
        private IApiCaller _apiCaller { get; set; }
        private IOrderApiAsync _orderApiAsync;
        public OfferApiSync(IApiCaller apiCaller, IOrderApiAsync orderApiAsync, IOptions<ChannelApiSetting> options)
        {
            _apiCaller = apiCaller;
            _baseUrl = options.Value.BaseUrl + options.Value.Offer;
            _token = options.Value.Token;
            _orderApiAsync = orderApiAsync;
        }
        public async Task<UpdateStockResponse> OfferStockUpdateAsync(List<MerchantOfferStockUpdateRequest> merchantOfferStockUpdateRequest)
        {
            var queryString = new Dictionary<String, String>();
            queryString.Add("apikey", _token);
            var requstOption = new RequestOption();
            requstOption.Url = _baseUrl;
            requstOption.QueryStringItems = queryString;
            requstOption.HeaderParameters.Add("Accept", "application/json");
            requstOption.Body = merchantOfferStockUpdateRequest;
            var result = await _apiCaller.PutAsync<UpdateStockResponse>(requstOption);
            return result;
        }
        public async Task<UpdateStockResponse> UpdateStockCountAsync()
        {
            var inProgressOrders = await _orderApiAsync.OrderGetByFilterAsync(new OrderFilterOption { Statuses = new List<OrderStatusView> { OrderStatusView.IN_PROGRESS } });
            var firstLine = inProgressOrders.Content.FirstOrDefault().Lines.FirstOrDefault();
            var result = await OfferStockUpdateAsync(new List<MerchantOfferStockUpdateRequest> {
            new MerchantOfferStockUpdateRequest
            {
                MerchantProductNo=firstLine.MerchantProductNo,
                StockLocations=new List<MerchantStockLocationUpdateRequest>()
                {
                    new MerchantStockLocationUpdateRequest
                    {
                        Stock=25,
                        StockLocationId=firstLine.StockLocation.StockLocationId
                    }
                }
            }
            });
            return result;
        }

    }
}
