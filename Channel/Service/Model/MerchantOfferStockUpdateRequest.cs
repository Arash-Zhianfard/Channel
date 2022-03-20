namespace Service.Model
{
    public class MerchantOfferStockUpdateRequest
    {
        public string MerchantProductNo { get; set; }
        public List<MerchantStockLocationUpdateRequest> StockLocations { get; set; }
    }
}
