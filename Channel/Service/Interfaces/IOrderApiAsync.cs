using Service.Model;

namespace Service.Interfaces
{
    public interface IOrderApiAsync
    {
        Task<ProductOrderResponse> OrderGetByFilterAsync(OrderFilterOption orderOption);
    }
}
