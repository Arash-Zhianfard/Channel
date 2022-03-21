using Microsoft.Extensions.Options;
using Service.Interfaces;
using Service.Model;
using System.Net;

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

        public async Task<ProductOrderResponse> GetByFilterAsync(OrderFilterOption orderOption)
        {
            try
            {
                RequestOption localVarRequestOptions = new RequestOption();
                var filters = new Dictionary<String, String>();
                if (orderOption.Statuses != null)
                {
                    orderOption.Statuses.ForEach(x => { filters.Add("Statuses", x.ToString()); });
                }
                if (orderOption.EmailAddresses != null)
                {
                    orderOption.EmailAddresses.ForEach(x => { filters.Add("EmailAddresses", x.ToString()); });
                }
                if (orderOption.MerchantOrderNos != null)
                {
                    orderOption.MerchantOrderNos.ForEach(x => { filters.Add("MerchantOrderNos", x.ToString()); });
                }
                if (orderOption.ChannelOrderNos != null)
                {
                    orderOption.ChannelOrderNos.ForEach(x => { filters.Add("ChannelOrderNos", x.ToString()); });
                }
                if (orderOption.FromDate != null)
                {
                    filters.Add("FromDate", orderOption.FromDate.ToString());
                }

                if (orderOption.ToDate != null)
                {
                    filters.Add("ToDate", orderOption.ToDate.ToString());
                }
                if (orderOption.FromCreatedAtDate != null)
                {
                    filters.Add("FromCreatedAtDate", orderOption.FromCreatedAtDate.ToString());
                }
                if (orderOption.ToCreatedAtDate != null)
                {
                    filters.Add("ToCreatedAtDate", orderOption.ToCreatedAtDate.ToString());
                }
                if (orderOption.FulfillmentType != null)
                {
                    filters.Add("fulfillmentType", orderOption.FulfillmentType.ToString());
                }
                if (orderOption.OnlyWithCancellationRequests != null)
                {
                    filters.Add("onlyWithCancellationRequests", orderOption.OnlyWithCancellationRequests.ToString());
                }
                if (orderOption.ChannelIds != null)
                {
                    orderOption.ChannelIds.ForEach(x => { filters.Add("channelIds", x.ToString()); });
                }
                if (orderOption.StockLocationIds != null)
                {
                    orderOption.StockLocationIds.ForEach(x => { filters.Add("stockLocationIds", x.ToString()); });
                }
                if (orderOption.IsAcknowledged != null)
                {
                    filters.Add("isAcknowledged", orderOption.IsAcknowledged.ToString());
                }
                if (orderOption.FromUpdatedAtDate != null)
                {
                    filters.Add("FromUpdatedAtDate", orderOption.FromUpdatedAtDate.ToString());
                }
                if (orderOption.ToUpdatedAtDate != null)
                {
                    filters.Add("toUpdatedAtDate", orderOption.ToUpdatedAtDate.ToString());
                }
                if (orderOption.Page != null)
                {
                    filters.Add("Page", orderOption.Page.ToString());
                }
                filters.Add("apikey", _token);
                var requstOption = new RequestOption();
                requstOption.Url = _baseUrl;
                requstOption.QueryStringItems = filters;
                requstOption.HeaderParameters.Add("Accept", "application/json");
                var response = await _apiCaller.GetAsync<ProductOrderResponse>(requstOption);
                return response;
            }
            catch (Exception ex) 
            {
                return new ProductOrderResponse()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "something went wrong",
                    Success = false
                };
            }
        }
    }
}