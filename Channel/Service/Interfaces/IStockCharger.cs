using Service.Model;

namespace Service.Interfaces
{
    public interface IStockCharger
    {
        Task<UpdateStockResponse> UpdateStockCountAsync();
    }
}
