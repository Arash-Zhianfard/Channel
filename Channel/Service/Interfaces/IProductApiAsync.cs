using Service.Model;

namespace Service.Interfaces
{
    public interface IProductApiAsync
    {
        Task<IEnumerable<TopSoldProduct>> GetTopSoldProduct(int number);
    }
}
