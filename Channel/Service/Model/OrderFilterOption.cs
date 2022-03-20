using ChannelEngine.Merchant.ApiClient.Model;

namespace Service.Model
{
    public class OrderFilterOption
    {
        public List<OrderStatusView> Statuses = null;
        public List<string> EmailAddresses { get; set; } = null;
        public List<string> MerchantOrderNos { get; set; } = null;
        public List<string> ChannelOrderNos { get; set; } = null;
        public DateTime? FromDate { get; set; } = null;
        public DateTime? ToDate { get; set; } = null;
        public DateTime? FromCreatedAtDate { get; set; } = null;
        public DateTime? ToCreatedAtDate { get; set; } = null;
        public bool? ExcludeMarketplaceFulfilledOrdersAndLines { get; set; } = null;
        public object? FulfillmentType { get; set; } = null;
        public bool? OnlyWithCancellationRequests { get; set; } = null;
        public List<int> ChannelIds { get; set; } = null;
        public List<int> StockLocationIds { get; set; } = null;
        public bool? IsAcknowledged { get; set; } = null;
        public DateTime? FromUpdatedAtDate { get; set; } = null;
        public DateTime? ToUpdatedAtDate { get; set; } = null;
        public int? Page { get; set; } = null;
    }
}
