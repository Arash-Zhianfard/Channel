using Service.Model;

namespace Service.Implementation
{
    public interface IOfferApiSync
    {
        Task<UpdateStockResponse> OfferStockUpdateAsync(List<MerchantOfferStockUpdateRequest> merchantOfferStockUpdateRequest);        
    }
}
