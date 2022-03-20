using Service.Model;

namespace Service.Interfaces
{
    public interface IProductAsync
    {
        Task<IEnumerable<TopSoldProduct>> GetTopSoldProduct(int number);
    }
}
