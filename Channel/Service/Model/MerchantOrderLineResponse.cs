using ChannelEngine.Merchant.ApiClient.Model;

namespace Service.Model
{
    public class MerchantOrderLineResponse
    {
        public OrderStatusView? Status { get; set; }
        public object? Condition { get; set; }
        public bool IsFulfillmentByMarketplace { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public StockLocation StockLocation { get; set; }
        public decimal? UnitVat { get; set; }
        public decimal? LineTotalInclVat { get; set; }
        public decimal? LineVat { get; set; }
        public decimal? OriginalUnitPriceInclVat { get; set; }
        public decimal? OriginalUnitVat { get; set; }
        public decimal? OriginalLineTotalInclVat { get; set; }
        public decimal? OriginalLineVat { get; set; }
        public decimal OriginalFeeFixed { get; set; }
        public string BundleProductMerchantProductNo { get; set; }
        public string JurisCode { get; set; }
        public string JurisName { get; set; }
        public decimal VatRate { get; set; }
        public List<object> ExtraData { get; set; }
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
        public int Quantity { get; set; }
        public int CancellationRequestedQuantity { get; set; }
        public decimal UnitPriceInclVat { get; set; }
        public decimal FeeFixed { get; set; }
        public decimal FeeRate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }

    }

}
