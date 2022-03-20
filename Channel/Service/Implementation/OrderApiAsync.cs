using Microsoft.Extensions.Options;
using Service.Interfaces;
using Service.Model;

namespace ChannelEngine.Merchant.ApiClient.Api
{
    public class OrderApiAsync : IOrderApiAsync
    {
        private string _baseUrl;
        private string _token;
        private IApiCaller _apiCaller { get; set; }
        public OrderApiAsync(IApiCaller apiCaller, IOptions<ChannelApiSetting> options)
        {
            _apiCaller = apiCaller;
            _baseUrl = options.Value.BaseUrl + options.Value.Order;
            _token = options.Value.Token;
        }

        public async Task<ProductOrderResponse> OrderGetByFilterAsync(OrderFilterOption orderOption)
        {
            RequestOption localVarRequestOptions = new RequestOption();
            String[] _contentTypes = new String[] {
            };
            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };
            var dic = new Dictionary<String, String>();


            if (orderOption.Statuses != null)
            {
                orderOption.Statuses.ForEach(x => { dic.Add("Statuses", x.ToString()); });
            }
            if (orderOption.EmailAddresses != null)
            {
                orderOption.EmailAddresses.ForEach(x => { dic.Add("EmailAddresses", x.ToString()); });
            }
            if (orderOption.MerchantOrderNos != null)
            {
                orderOption.MerchantOrderNos.ForEach(x => { dic.Add("MerchantOrderNos", x.ToString()); });
            }
            if (orderOption.ChannelOrderNos != null)
            {
                orderOption.ChannelOrderNos.ForEach(x => { dic.Add("ChannelOrderNos", x.ToString()); });
            }
            if (orderOption.FromDate != null)
            {
                dic.Add("FromDate", orderOption.FromDate.ToString());
            }

            if (orderOption.ToDate != null)
            {
                dic.Add("ToDate", orderOption.ToDate.ToString());
            }
            if (orderOption.FromCreatedAtDate != null)
            {
                dic.Add("FromCreatedAtDate", orderOption.FromCreatedAtDate.ToString());
            }
            if (orderOption.ToCreatedAtDate != null)
            {
                dic.Add("ToCreatedAtDate", orderOption.ToCreatedAtDate.ToString());
            }
            //if (orderOption.EexcludeMarketplaceFulfilledOrdersAndLines != null)
            //{
            //    (ChannelEngine.Merchant.ApiClient.Client.ClientUtils.ParameterToMultiMap("", "excludeMarketplaceFulfilledOrdersAndLines", excludeMarketplaceFulfilledOrdersAndLines));
            //}
            if (orderOption.FulfillmentType != null)
            {
                dic.Add("fulfillmentType", orderOption.FulfillmentType.ToString());
            }
            if (orderOption.OnlyWithCancellationRequests != null)
            {
                dic.Add("onlyWithCancellationRequests", orderOption.OnlyWithCancellationRequests.ToString());
            }
            if (orderOption.ChannelIds != null)
            {
                orderOption.ChannelIds.ForEach(x => { dic.Add("channelIds", x.ToString()); });
            }
            if (orderOption.StockLocationIds != null)
            {
                orderOption.StockLocationIds.ForEach(x => { dic.Add("stockLocationIds", x.ToString()); });
            }
            if (orderOption.IsAcknowledged != null)
            {
                dic.Add("isAcknowledged", orderOption.IsAcknowledged.ToString());
            }
            if (orderOption.FromUpdatedAtDate != null)
            {
                dic.Add("FromUpdatedAtDate", orderOption.FromUpdatedAtDate.ToString());
            }
            if (orderOption.ToUpdatedAtDate != null)
            {
                dic.Add("toUpdatedAtDate", orderOption.ToUpdatedAtDate.ToString());
            }
            if (orderOption.Page != null)
            {
                dic.Add("Page", orderOption.Page.ToString());
            }
            dic.Add("apikey", _token);
            var requstOption = new RequestOption();
            requstOption.ContentType = "application/json";
            requstOption.Url = _baseUrl;
            requstOption.QueryStringItems = dic;
            requstOption.HeaderParameters.Add("Accept", "application/json");
            var response = await _apiCaller.GetAsync<ProductOrderResponse>(requstOption);
            return response;
        }
    }
}