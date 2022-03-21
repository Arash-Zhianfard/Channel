using Service.Model;

namespace Service.Interfaces
{
    public interface IProductApiAsync
    {
        Task<TopSoldProductResponse> GetTopSoldProduct(int number);
    }
}
