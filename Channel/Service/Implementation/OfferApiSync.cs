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
        public OfferApiSync(IApiCaller apiCaller, IOptions<ChannelApiSetting> options)
        {
            _apiCaller = apiCaller;
            _baseUrl = options.Value.BaseUrl + options.Value.Offer;
            _token = options.Value.Token;            
        }
        public async Task<UpdateStockResponse> OfferStockUpdateAsync(List<MerchantOfferStockUpdateRequest> merchantOfferStockUpdateRequest)
        {
            var queryString = new Dictionary<String, String>();
            queryString.Add("apikey", _token);
            var requstOption = new RequestOption();
            requstOption.Url = _baseUrl;
            requstOption.QueryStringItems = queryString;            
            requstOption.Body = merchantOfferStockUpdateRequest;
            var stockUpdateReponse = await _apiCaller.PutAsync<UpdateStockResponse>(requstOption);
            return stockUpdateReponse;
        }
   
    }
}
